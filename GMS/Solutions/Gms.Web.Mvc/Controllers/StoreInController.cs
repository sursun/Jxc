using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gms.Common;
using Gms.Domain;
using Gms.Infrastructure;
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
        
        [Transaction]
        public ActionResult SaveOrUpdate(StoreIn obj)
        {
            try
            {
                if (obj.Id > 0)
                {
                    obj = this.StoreInRepository.Get(obj.Id);
                    TryUpdateModel(obj);
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