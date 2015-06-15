using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
using Gms.Web.Mvc.Controllers.Attribute;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    [HandleError]
    [Authorize]
    public class EquiStoreController : BaseController
    {
        #region 入库

        public ActionResult StoreIn()
        {
            return View();
        }

        public ActionResult StoreInList(EquiStoreInQuery query)
        {
            var list = this.EquiStoreInRepository.GetList(query);
            var data = list.Data.Select(c => EquiStoreInModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
        
        public ActionResult EditIn(int id)
        {
            var item = this.EquiStoreInRepository.Get(id);
            if (item == null)
            {
                item = new EquiStoreIn();
                item.CreateDateTime = DateTime.Now;
                item.User = CurrentUser;
                item.CodeNo = item.CreateDateTime.ToString("yyyyMMddHHmmss");
            }
            return View(item);
        }

        public ActionResult EquiInList(EquiInQuery query)
        {
            var list = this.EquiInRepository.GetAll(query);
            var data = list.Select(c => EquipmentModel.From(c)).ToList();
            var result = new { total = list.Count, rows = data };
            return Json(result);
        }

        [Transaction]
        public ActionResult StoreInSaveOrUpdate(int id, string codeno, int equifromid, string note, string equis,decimal price)
        {
            try
            {
                var jser = new JavaScriptSerializer();
                IList<EquipmentModel> datas = jser.Deserialize<IList<EquipmentModel>>(equis);

                EquiStoreIn equiStoreIn = this.EquiStoreInRepository.Get(id);
                if (equiStoreIn == null)
                {
                    equiStoreIn = new EquiStoreIn();
                    equiStoreIn.CodeNo = codeno;
                    equiStoreIn.CreateDateTime = DateTime.Now;
                }

                equiStoreIn.EquiFrom = this.CommonCodeRepository.Get(equifromid);
                equiStoreIn.Note = note;
                equiStoreIn.Price = price;
                equiStoreIn.User = CurrentUser;

                equiStoreIn = this.EquiStoreInRepository.SaveOrUpdate(equiStoreIn);

                int quantity = 0;
                IList<EquiIn> newDatas = new List<EquiIn>();

                IList<EquiIn> oldDatas = this.EquiInRepository.GetBy(equiStoreIn.Id);

                //找到存在的进行更新
                foreach (var item1 in oldDatas)
                {
                    bool bFlag = false;

                    for (int i = datas.Count - 1; i >= 0; i--)
                    {
                        var item2 = datas[i];

                        if (item1.Equipment.Id == item2.Id)
                        {
                            //
                            //计算物料最新数量
                            //
                            item1.OldQuantity = item1.Equipment.Quantity;//记录原库存量
                            item1.Equipment.Quantity -= item1.Quantity;
                            if (item1.Equipment.Quantity < 0)
                            {
                                item1.Equipment.Quantity = 0;
                            }
                            item1.Equipment.Quantity += item2.Quantity;
                            
                            item1.Price = item2.Price;
                            item1.Quantity = item2.Quantity;

                            newDatas.Add(item1);
                            datas.Remove(item2);

                            bFlag = true;
                        }
                    }

                    //不存在 就删除
                    if (!bFlag)
                    {
                        //直接删除，不处理价格
                        item1.Equipment.Quantity -= item1.Quantity;
                        this.EquipmentRepository.SaveOrUpdate(item1.Equipment);

                        this.EquiInRepository.Delete(item1);
                    }
                }

                //添加新增的
                foreach (var item in datas)
                {
                    var equi = this.EquipmentRepository.Get(item.Id) ;
                    var oldQuantity = equi.Quantity;//记录原库存量
                    equi.Quantity += item.Quantity;

                    newDatas.Add(new EquiIn()
                    {
                        EquiStoreIn = equiStoreIn,
                        Equipment = equi,
                        OldQuantity = oldQuantity,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                //循环保存入库物料
                foreach (var item in newDatas)
                {
                    //更新物料价格及数量
                    EquipmentUpdate(item);

                    this.EquiInRepository.SaveOrUpdate(item);
                    
                    
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }

        [Transaction]
        public void EquipmentUpdate(EquiIn equiIn)
        {
            if (equiIn.Equipment == null)
                return;

            Equipment equi = equiIn.Equipment;

            //检查价格是否变化
            if (equi.Price != equiIn.Price)
            {
                //记录价格变化
                EquiPriceChange entity = new EquiPriceChange();
                entity.EquiIn = equiIn;
                entity.Quantity = equiIn.OldQuantity;
                entity.OldPrice = equi.Price;
                entity.NewPrice = equiIn.Price;
                entity.User = CurrentUser;
                entity.CreateDateTime = DateTime.Now;
                this.EquiPriceChangeRepository.SaveOrUpdate(entity);

                equi.Price = equiIn.Price;
            }
            
            this.EquipmentRepository.SaveOrUpdate(equi);
        }

        #endregion

        #region 出库

        public ActionResult StoreOut()
        {
            return View();
        }

        public ActionResult StoreOutList(EquiStoreOutQuery query)
        {
            var list = this.EquiStoreOutRepository.GetList(query);
            var data = list.Data.Select(c => EquiStoreOutModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult EditOut(int id)
        {
            var item = this.EquiStoreOutRepository.Get(id);
            if (item == null)
            {
                item = new EquiStoreOut();
                item.CreateDateTime = DateTime.Now;
                item.User = CurrentUser;
                item.CodeNo = item.CreateDateTime.ToString("yyyyMMddHHmmss");
            }
            return View(item);
        }

        public ActionResult EquiOutList(EquiOutQuery query)
        {
            var list = this.EquiOutRepository.GetAll(query);
            var data = list.Select(c => EquipmentModel.From(c)).ToList();
            var result = new { total = list.Count, rows = data };
            return Json(result);
        }

        [Transaction]
        public ActionResult StoreOutSaveOrUpdate(int id, string codeno, int equitoid, string note, string equis, decimal price)
        {
            try
            {
                var jser = new JavaScriptSerializer();
                IList<EquipmentModel> datas = jser.Deserialize<IList<EquipmentModel>>(equis);

                //
                //先检查库存是否足够
                //
                for (int i = datas.Count - 1; i >= 0; i--)
                {
                    var item = datas[i];
                    var equi = this.EquipmentRepository.Get(item.Id);
                    
                    if (equi.Quantity < item.Quantity)
                    {
                        throw new Exception(String.Format("{0}库存不足，仅有【{1}】", equi.Name, equi.Quantity));
                    }
                }
                

                EquiStoreOut equiStoreOut = this.EquiStoreOutRepository.Get(id);
                if (equiStoreOut == null)
                {
                    equiStoreOut = new EquiStoreOut();
                    equiStoreOut.CodeNo = codeno;
                    equiStoreOut.CreateDateTime = DateTime.Now;
                }

                equiStoreOut.EquiTo = this.CommonCodeRepository.Get(equitoid);
                equiStoreOut.Note = note;
                equiStoreOut.Price = price;
                equiStoreOut.User = CurrentUser;

                equiStoreOut = this.EquiStoreOutRepository.SaveOrUpdate(equiStoreOut);

                IList<EquiOut> newDatas = new List<EquiOut>();

                IList<EquiOut> oldDatas = this.EquiOutRepository.GetBy(equiStoreOut.Id);

                //找到存在的进行更新
                foreach (var item1 in oldDatas)
                {
                    bool bFlag = false;

                    for (int i = datas.Count - 1; i >= 0; i--)
                    {
                        var item2 = datas[i];

                        if (item1.Equipment.Id == item2.Id)
                        {
                            //更新物料数量
                            item1.Equipment.Quantity -= item2.Quantity;

                            item1.Price = item2.Price;
                            item1.Quantity = item2.Quantity;

                            newDatas.Add(item1);
                            datas.Remove(item2);

                            bFlag = true;
                        }
                    }

                    //不存在 就删除
                    if (!bFlag)
                    {
                        //删除的，因不存在于新列表中，故在此直接保存
                        item1.Equipment.Quantity += item1.Quantity;
                        this.EquipmentRepository.SaveOrUpdate(item1.Equipment);

                        this.EquiOutRepository.Delete(item1);
                    }
                }

                //添加新增的
                foreach (var item in datas)
                {
                    var equi = this.EquipmentRepository.Get(item.Id);
                    equi.Quantity -= item.Quantity;
                   
                    newDatas.Add(new EquiOut()
                    {
                        EquiStoreOut = equiStoreOut,
                        Equipment = equi,
                        Quantity = item.Quantity,
                        Price = item.Price
                    });
                }

                //循环保存出库物料
                foreach (var item in newDatas)
                {
                    //保存更新的物料数量
                    this.EquipmentRepository.SaveOrUpdate(item.Equipment);

                    this.EquiOutRepository.SaveOrUpdate(item);
                }
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }


        #endregion

    }

    /// <summary>
    /// 入库单
    /// </summary>
    public class EquiStoreInModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 入库单号
        /// </summary>
        public string CodeNo { get; set; }

        /// <summary>
        /// 来源
        /// 购买
        /// 赠送
        /// </summary>
        public string EquiFromName { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 入库人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 入库时间
        /// </summary>
        public string CreateDateTimeString { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public EquiStoreInModel(EquiStoreIn equiStoreIn)
        {
            this.Id = equiStoreIn.Id;
            this.CodeNo = equiStoreIn.CodeNo;
            this.EquiFromName = equiStoreIn.EquiFrom == null ? "" : equiStoreIn.EquiFrom.Name;
            this.Price = equiStoreIn.Price;
            this.UserName = equiStoreIn.User == null ? "" : equiStoreIn.User.LoginName;
            this.CreateDateTimeString = equiStoreIn.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.Note = equiStoreIn.Note;
        }

        public static EquiStoreInModel From(EquiStoreIn equiStoreIn)
        {
            return new EquiStoreInModel(equiStoreIn);
        }
    }

    /// <summary>
    /// 出库单
    /// </summary>
    public class EquiStoreOutModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 出库单号
        /// </summary>
        public string CodeNo { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string EquiToName { get; set; }

        /// <summary>
        /// 总价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 出库人
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 出库时间
        /// </summary>
        public string CreateDateTimeString { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Note { get; set; }

        public EquiStoreOutModel(EquiStoreOut equiStoreOut)
        {
            this.Id = equiStoreOut.Id;
            this.CodeNo = equiStoreOut.CodeNo;
            this.EquiToName = equiStoreOut.EquiTo == null ? "" : equiStoreOut.EquiTo.Name;
            this.Price = equiStoreOut.Price;
            this.UserName = equiStoreOut.User == null ? "" : equiStoreOut.User.LoginName;
            this.CreateDateTimeString = equiStoreOut.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.Note = equiStoreOut.Note;
        }

        public static EquiStoreOutModel From(EquiStoreOut equiStoreOut)
        {
            return new EquiStoreOutModel(equiStoreOut);
        }
    }
 


}