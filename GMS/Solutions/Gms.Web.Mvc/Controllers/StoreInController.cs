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
    public class StoreInController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List(StoreInQuery query)
        {
            var list = this.StoreInRepository.GetList(query);
            var data = list.Data.Select(c => StoreInModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }
        
        public ActionResult Add()
        {
            return View(new StoreIn());
        }

        public ActionResult Edit(int id)
        {
            StoreIn item = this.StoreInRepository.Get(id);
            
            return View(item);
        }

        public ActionResult Detail(int id)
        {
            StoreIn item = this.StoreInRepository.Get(id);
            
            return View(item);
        }
        
        [Transaction]
        public ActionResult SaveOrUpdate(StoreIn obj, string sgoods)
        {
            try
            {
                if (obj.Id > 0)
                {
                    obj = this.StoreInRepository.Get(obj.Id);
                    TryUpdateModel(obj);


                    var jser = new JavaScriptSerializer();
                    IList<StoreInDetailModel> datas = jser.Deserialize<IList<StoreInDetailModel>>(sgoods);


                    var list = this.StoreInDetailRepository.GetAll(new StoreInDetailQuery
                    {
                        StoreInId = obj.Id
                    });

                    IList<StoreInDetail> dts = new List<StoreInDetail>();

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
                            this.StoreInDetailRepository.Delete(item1);
                        }
                    }

                    //添加新增的
                    foreach (var item in datas)
                    {
                        dts.Add(new StoreInDetail()
                        {
                            StoreIn = obj,
                            Goods = this.GoodsRepository.Get(item.Id),
                            Price = item.Price,
                            Quantity = item.StoreGoodsQuantity,
                            TotalAomount = item.TotalAomount,
                            Note = item.StoreGoodsNote
                        });
                    }
                    
                    foreach (var item in dts)
                    {
                        this.StoreInDetailRepository.SaveOrUpdate(item);
                    }
                }
                else
                {
                    if (obj.Store == null)
                    {
                        return JsonError("请选择仓库");
                    }

                    if (obj.Supplier == null)
                    {
                        return JsonError("请选择供应商");
                    }

                    if (obj.Buyer == null)
                    {
                        return JsonError("请选择采购员");
                    }
                }

                obj = this.StoreInRepository.SaveOrUpdate(obj);
                
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
                var obj = this.StoreInRepository.Get(id);

                var list = this.StoreInDetailRepository.GetAll(new StoreInDetailQuery
                {
                    StoreInId = obj.Id
                });

                if (list.Count > 0)
                {
                    return JsonError("入库单中存在商品，请清空后再试！");
                }

                this.StoreInRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        #region 商品维护

        public ActionResult DetailList(int storeInId)
        {
            var list = this.StoreInDetailRepository.GetAll(new StoreInDetailQuery
            {
                StoreInId = storeInId
            });

            var data = list.Select(c => StoreInDetailModel.From(c)).ToList();
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
            var item = this.StoreInRepository.Get(id);

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

                item = this.StoreInRepository.SaveOrUpdate(item);

                return JsonSuccess(item);
            }

            return JsonError("审核失败，请刷新后再试");
        }
   
        
        #endregion

    }

    /// <summary>
    /// 商品出入库
    /// </summary>
    public class StoreAlterModel:AuditBaseModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public String OrderCode { get; set; }

        /// <summary>
        /// 单据日期
        /// </summary>
        public String OrderTimeStr { get; set; }

        /// <summary>
        /// 仓库
        /// </summary>
        public int StoreId { get; set; }
        public String StoreName { get; set; }

        /// <summary>
        /// 结算账户
        /// </summary>
        public int AccountId { get; set; }
        public String AccountName { get; set; }

        /// <summary>
        /// 本次应付(收)款
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 本次欠款
        /// </summary>
        public decimal Debt { get; set; }

        /// <summary>
        /// 付款人
        /// </summary>
        public String Payer { get; set; }

        /// <summary>
        /// 收款人
        /// </summary>
        public String Payee { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public StoreAlterModel(StoreAlter storeAlter)
            : base(storeAlter)
        {
            this.Id = storeAlter.Id;
            this.CodeNo = storeAlter.CodeNo;
            this.OrderCode = storeAlter.OrderCode;
            this.OrderTimeStr = storeAlter.OrderTime.ToString("yyyy-MM-dd HH:mm:ss");

            if (storeAlter.Store != null)
            {
                this.StoreId = storeAlter.Store.Id;
                this.StoreName = storeAlter.Store.Name;
            }

            if (storeAlter.Account != null)
            {
                this.AccountId = storeAlter.Account.Id;
                this.AccountName = storeAlter.Account.Name;
            }

            this.Amount = storeAlter.Amount;
            this.Debt = storeAlter.Debt;
            this.Payer = storeAlter.Payer;
            this.Payee = storeAlter.Payee;
            this.Note = storeAlter.Note;
        }

    }

    public class StoreInModel : StoreAlterModel
    {
        /// <summary>
        /// 供应商
        /// </summary>
        public int SupplierId { get; set; }
        public String SupplierName { get; set; }

        /// <summary>
        /// 采购员
        /// </summary>
        public int BuyerId { get; set; }
        public String BuyerName { get; set; }

        /// <summary>
        /// 入库类型
        /// 采购入库|其他入库
        /// </summary>
        public int StoreInTypeId { get; set; }
        public String StoreInTypeName { get; set; }

        /// <summary>
        /// 本次付款
        /// </summary>
        public decimal AmountPay { get; set; }

        public StoreInModel(StoreIn storeIn)
            : base(storeIn)
        {
            if (storeIn.Supplier != null)
            {
                this.SupplierId = storeIn.Supplier.Id;
                this.SupplierName = storeIn.Supplier.Name;
            }

            if (storeIn.Buyer != null)
            {
                this.BuyerId = storeIn.Buyer.Id;
                this.BuyerName = storeIn.Buyer.LoginName;
            }

            if (storeIn.StoreInType != null)
            {
                this.StoreInTypeId = storeIn.StoreInType.Id;
                this.StoreInTypeName = storeIn.StoreInType.Name;
            }

            this.AmountPay = storeIn.AmountPay;
        }

        public static StoreInModel From(StoreIn storeIn)
        {
            return new StoreInModel(storeIn);
        }
    }

    public class StoreInDetailModel : StoreGoodsModel
    {
        public int StoreInId { get; set; }
        public String StoreInCodeNo { get; set; }

        public StoreInDetailModel()
        {
        }


        public StoreInDetailModel(StoreInDetail storeInDetail)
            : base(storeInDetail)
        {
            if (storeInDetail.StoreIn != null)
            {
                this.StoreInId = storeInDetail.StoreIn.Id;
                this.StoreInCodeNo = storeInDetail.StoreIn.CodeNo;
            }
        }

        public static StoreInDetailModel From(StoreInDetail storeInDetail)
        {
            return new StoreInDetailModel(storeInDetail);
        }

    }

}