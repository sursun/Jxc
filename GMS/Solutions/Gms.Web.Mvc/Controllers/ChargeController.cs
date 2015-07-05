using System;
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
    public class ChargeController : BaseController
    {

        public ActionResult In()
        {
            return View();
        }

        public ActionResult Audit()
        {
            return View();
        }

        public ActionResult Edit(int? id,CommonCodeType? chargetype)
        {
            Charge item = null;
            ViewData["ChargeType"] = CommonCodeType.支出记账类型;

            if (id.HasValue)
            {
                item = this.ChargeRepository.Get(id.Value);
            }

            if (item == null )
            {
                item = new Charge();
                if (chargetype.HasValue)
                {
                    ViewData["ChargeType"] = chargetype.Value;
                }
            }

            return View(item);
        }

        public ActionResult List(ChargeQuery query)
        {
            var list = this.ChargeRepository.GetList(query);
            var data = list.Data.Select(c => ChargeModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data};
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(Charge item)
        {
            try
            {
                if (item.Id > 0)
                {
                    item = this.ChargeRepository.Get(item.Id);

                    TryUpdateModel(item);
                }
                else
                {
                    if(item.Account == null)
                        throw new Exception("请选择账户");
                    
                    if (item.Amount == 0)
                        throw new Exception("请输入记账金额");

                    item.OldAmount = item.Account.CurAmount;
                    item.Account.CurAmount -= item.Amount;
                    item.AutoCreate = Yesno.否;
                }

                item.AuditState = AuditState.未审核;

                item = this.ChargeRepository.SaveOrUpdate(item);

                return JsonSuccess(item);

            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        [Transaction]
        public ActionResult SaveAudit(int id, int pass)
        {
            var item = this.ChargeSwapRepository.Get(id);

            if (item != null)
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

                item = this.ChargeSwapRepository.SaveOrUpdate(item);

                return JsonSuccess(item);
            }
            
            return JsonError("审核失败，请刷新后再试");
        }
        
        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = this.ChargeRepository.Get(id);
            if (item != null)
            {
                if (item.AuditState == AuditState.未审核 || item.AuditState == AuditState.审核失败)
                {
                    this.ChargeRepository.Delete(item);
                }
                else
                {
                    return JsonError("只能删除‘未审核’和‘审核失败’的记账");
                }
                
            }
            
            return JsonSuccess();
        }
        
    }
    
    public class ChargeModel : AuditBaseModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 记账账户
        /// </summary>
        public int AccountId { get; set; }
        public String AccountName { get; set; }

        /// <summary>
        /// 记账前
        /// 账户金额
        /// </summary>
        public decimal OldAmount { get; set; }

        /// <summary>
        /// 收支类型
        /// </summary>
        public int ChargeTypeId { get; set; }
        public String ChargeTypeName { get; set; }

        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 经手人
        /// </summary>
        public int UserId { get; set; }
        public String UserName { get; set; }

        /// <summary>
        /// 是否自动记账？
        /// </summary>
        public String AutoCreate { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public ChargeModel(Charge charge):base(charge)
        {
            this.Id = charge.Id;

            if (charge.Account != null)
            {
                this.AccountId = charge.Account.Id;
                this.AccountName = charge.Account.Name;
            }

            this.OldAmount = charge.OldAmount;

            if (charge.ChargeType != null)
            {
                this.ChargeTypeId = charge.ChargeType.Id;
                this.ChargeTypeName = charge.ChargeType.Name;
            }

            this.Amount = charge.Amount;

            if (charge.User != null)
            {
                this.UserId = charge.User.Id;
                this.UserName = charge.User.LoginName;
            }

            this.AutoCreate = charge.AutoCreate.ToString();
            this.Note = charge.Note;
        }

        public static ChargeModel From(Charge charge)
        {
            return new ChargeModel(charge);
        }
    }
}