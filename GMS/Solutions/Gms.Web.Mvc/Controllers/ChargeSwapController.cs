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
    public class ChargeSwapController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Audit()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            ChargeSwap item = null;

            if (id.HasValue)
            {
                item = this.ChargeSwapRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new ChargeSwap();
            }

            return View(item);
        }

        public ActionResult Info(int? id)
        {
            ChargeSwap item = null;

            if (id.HasValue)
            {
                item = this.ChargeSwapRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new ChargeSwap();
            }

            return View(item);
        }

        public ActionResult List(ChargeSwapQuery query)
        {
            var list = this.ChargeSwapRepository.GetList(query);
            var data = list.Data.Select(c => ChargeSwapModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data};
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(ChargeSwap item)
        {
            try
            {
                if (item.Id > 0)
                {
                    item = this.ChargeSwapRepository.Get(item.Id);

                    TryUpdateModel(item);
                }
                else
                {
                    if(item.OrigAccount == null)
                        throw new Exception("请选择源账户");

                    if (item.DestAccount == null)
                        throw new Exception("请选择目的账户");

                    if (item.Amount == 0)
                        throw new Exception("请输入记账金额");

                    item.OrigAmount = item.OrigAccount.CurAmount;
                    item.OrigAccount.CurAmount -= item.Amount;

                    item.DestAmount = item.DestAccount.CurAmount;
                    item.DestAccount.CurAmount += item.Amount;

                }

                item.AuditState = AuditState.未审核;

                item = this.ChargeSwapRepository.SaveOrUpdate(item);

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

                item = this.ChargeSwapRepository.SaveOrUpdate(item);

                return JsonSuccess(item);
            }
            
            return JsonError("审核失败，请刷新后再试");
        }
        
        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = this.ChargeSwapRepository.Get(id);
            if (item != null)
            {
                if (item.AuditState == AuditState.未审核 || item.AuditState == AuditState.审核失败)
                {
                    this.ChargeSwapRepository.Delete(item);
                }
                else
                {
                    return JsonError("只能删除‘未审核’和‘审核失败’的记账");
                }
                
            }
            
            return JsonSuccess();
        }
        
    }

    public class AuditBaseModel
    {
        /// <summary>
        /// 登记人
        /// </summary>
        public int CreatorId { get; set; }
        public String CreatorName { get; set; }

        /// <summary>
        /// 登记日期
        /// </summary>
        public String CreateTimeString { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public int AuditorId { get; set; }
        public String AuditorName { get; set; }

        /// <summary>
        /// 审核日期
        /// </summary>
        public String AuditTimeString { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public String AuditState { get; set; }

        /// <summary>
        /// 审核说明
        /// </summary>
        public String AuditNote { get; set; }

        public AuditBaseModel(AuditBase auditBase)
        {
            if (auditBase.Creator != null)
            {
                this.CreatorId = auditBase.Creator.Id;
                this.CreatorName = auditBase.Creator.LoginName;
            }

            this.CreateTimeString = auditBase.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");

            if (auditBase.Auditor != null)
            {
                this.AuditorId = auditBase.Auditor.Id;
                this.AuditorName = auditBase.Auditor.LoginName;
            }

            this.AuditTimeString = auditBase.AuditTime.ToString("yyyy-MM-dd HH:mm:ss");
            this.AuditState = auditBase.AuditState.ToString();
            this.AuditNote = auditBase.AuditNote;
        }

    }

    public class ChargeSwapModel : AuditBaseModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 源账户
        /// </summary>
        public int OrigAccountId { get; set; }
        public String OrigAccountName { get; set; }

        /// <summary>
        /// 目的账户
        /// </summary>
        public int DestAccountId { get; set; }
        public String DestAccountName { get; set; }

        /// <summary>
        /// 变化前
        /// 源账户金额
        /// </summary>
        public decimal OrigAmount { get; set; }

        /// <summary>
        /// 变化前
        /// 目的账户金额
        /// </summary>
        public decimal DestAmount { get; set; }

        /// <summary>
        /// 记账金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public ChargeSwapModel(ChargeSwap chargeSwap):base(chargeSwap)
        {
            this.Id = chargeSwap.Id;

            if (chargeSwap.OrigAccount != null)
            {
                this.OrigAccountId = chargeSwap.OrigAccount.Id;
                this.OrigAccountName = chargeSwap.OrigAccount.Name;
            }

            if (chargeSwap.DestAccount != null)
            {
                this.DestAccountId = chargeSwap.DestAccount.Id;
                this.DestAccountName = chargeSwap.DestAccount.Name;
            }

            this.OrigAmount = chargeSwap.OrigAmount;
            this.DestAmount = chargeSwap.DestAmount;
            this.Amount = chargeSwap.Amount;
            this.Note = chargeSwap.Note;
        }

        public static ChargeSwapModel From(ChargeSwap chargeSwap)
        {
            return new ChargeSwapModel(chargeSwap);
        }
    }
}