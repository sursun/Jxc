using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
using NUnit.Framework.Constraints;
using SharpArch.NHibernate.Contracts.Repositories;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    //[HandleError]
    //[Authorize]
    public class StoreOutController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(StoreOutQuery query)
        {
            var list = this.StoreOutRepository.GetList(query);
            var data = list.Data.Select(c => StoreOutModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
        
        public ActionResult Add()
        {
            return View(new StoreOut());
        }

        public ActionResult Edit(int id)
        {
            StoreOut item = this.StoreOutRepository.Get(id);
            
            return View(item);
        }

        public ActionResult Detail(int id)
        {
            StoreOut item = this.StoreOutRepository.Get(id);
            
            return View(item);
        }
        
        [Transaction]
        public ActionResult SaveOrUpdate(StoreOut obj, string sgoods)
        {
            try
            {
                if (obj.Id > 0)
                {
                    obj = this.StoreOutRepository.Get(obj.Id);
                    TryUpdateModel(obj);


                    var jser = new JavaScriptSerializer();
                    IList<StoreOutDetailModel> datas = jser.Deserialize<IList<StoreOutDetailModel>>(sgoods);


                    var list = this.StoreOutDetailRepository.GetAll(new StoreOutDetailQuery
                    {
                        StoreOutId = obj.Id
                    });

                    IList<StoreOutDetail> dts = new List<StoreOutDetail>();

                    //找到存在的进行更新,不存在的删除
                    foreach (var item1 in list)
                    {
                        bool bFlag = false;

                        for (int i = datas.Count - 1; i >= 0; i--)
                        {
                            var item2 = datas[i];

                            if (item1.Goods.Id == item2.Id)
                            {
                                item1.Price = item2.Price;
                                item1.Quantity = item2.StoreGoodsQuantity;
                                item1.TotalAomount = item2.TotalAomount;
                                item1.Note = item2.StoreGoodsNote;

                                dts.Add(item1);
                                datas.Remove(item2);

                                bFlag = true;
                            }
                        }

                        if (!bFlag)
                        {
                            this.StoreOutDetailRepository.Delete(item1);
                        }
                    }

                    //添加新增的
                    foreach (var item in datas)
                    {
                        dts.Add(new StoreOutDetail()
                        {
                            StoreOut = obj,
                            Goods = this.GoodsRepository.Get(item.Id),
                            Price = item.Price,
                            Quantity = item.StoreGoodsQuantity,
                            TotalAomount = item.TotalAomount,
                            Note = item.StoreGoodsNote
                        });
                    }
                    
                    foreach (var item in dts)
                    {
                        this.StoreOutDetailRepository.SaveOrUpdate(item);
                    }
                }
                else
                {
                    if (obj.Store == null)
                    {
                        return JsonError("请选择仓库");
                    }

                    if (obj.Customer == null)
                    {
                        return JsonError("请选择客户");
                    }

                    if (obj.Seller == null)
                    {
                        return JsonError("请选择销售员");
                    }
                }

                obj = this.StoreOutRepository.SaveOrUpdate(obj);
                
                return JsonSuccess(obj);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.StoreOutRepository.Get(id);

                var list = this.StoreOutDetailRepository.GetAll(new StoreOutDetailQuery
                {
                    StoreOutId = obj.Id
                });

                if (list.Count > 0)
                {
                    return JsonError("出库单中存在商品，请清空后再试！");
                }

                this.StoreOutRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        #region 商品维护

        public ActionResult DetailList(int storeOutId)
        {
            var list = this.StoreOutDetailRepository.GetAll(new StoreOutDetailQuery
            {
                StoreOutId = storeOutId
            });

            var data = list.Select(c => StoreOutDetailModel.From(c)).ToList();
            var result = new { total = list.Count, rows = data };
            return Json(result);
        }
        
        #endregion
        
        #region 商品审核

        public ActionResult Audit()
        {
            return View();
        }

        [Transaction]
        public ActionResult SaveAudit(int id, int pass)
        {
            var item = this.StoreOutRepository.Get(id);

            if (item != null && item.AuditState == AuditState.未审核)
            {
                item.Auditor = CurrentUser;
                item.AuditTime = DateTime.Now;

                if (pass == 1)
                {
                    item.AuditState = AuditState.审核成功;
                }
                else
                {
                    item.AuditState = AuditState.审核失败;
                }

                item = this.StoreOutRepository.SaveOrUpdate(item);

                return JsonSuccess(item);
            }

            return JsonError("审核失败，请刷新后再试");
        }
   
        
        #endregion

    }


    public class StoreOutModel : StoreAlterModel
    {
        /// <summary>
        /// 客户
        /// </summary>
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        /// <summary>
        /// 业务员
        /// </summary>
        public int SellerId { get; set; }
        public string SellerName { get; set; }

        /// <summary>
        /// 出库类型
        /// 销售出库|其他出库
        /// </summary>
        public int StoreOutTypeId { get; set; }
        public string StoreOutTypeName { get; set; }

        /// <summary>
        /// 本次收款
        /// </summary>
        public decimal AmountReceipt { get; set; }


        public StoreOutModel(StoreOut storeOut)
            : base(storeOut)
        {
            if (storeOut.Customer != null)
            {
                this.CustomerId = storeOut.Customer.Id;
                this.CustomerName = storeOut.Customer.Name;
            }

            if (storeOut.Seller != null)
            {
                this.SellerId = storeOut.Seller.Id;
                this.SellerName = storeOut.Seller.LoginName;
            }

            if (storeOut.StoreOutType != null)
            {
                this.StoreOutTypeId = storeOut.StoreOutType.Id;
                this.StoreOutTypeName = storeOut.StoreOutType.Name;
            }

            this.AmountReceipt = storeOut.AmountReceipt;
        }

        public static StoreOutModel From(StoreOut storeOut)
        {
            return new StoreOutModel(storeOut);
        }
    }

    public class StoreOutDetailModel : StoreGoodsModel
    {
        public int StoreOutId { get; set; }
        public String StoreOutCodeNo { get; set; }

        public StoreOutDetailModel()
        {
        }


        public StoreOutDetailModel(StoreOutDetail storeOutDetail)
            : base(storeOutDetail)
        {
            if (storeOutDetail.StoreOut != null)
            {
                this.StoreOutId = storeOutDetail.StoreOut.Id;
                this.StoreOutCodeNo = storeOutDetail.StoreOut.CodeNo;
            }
        }

        public static StoreOutDetailModel From(StoreOutDetail storeOutDetail)
        {
            return new StoreOutDetailModel(storeOutDetail);
        }

    }

}