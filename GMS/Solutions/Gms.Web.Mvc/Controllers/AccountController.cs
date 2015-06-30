using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentNHibernate.Utils;
using Gms.Domain;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }

        public ActionResult GetAccount(int? id)
        {
            Account item = null;
 
            if (id.HasValue)
            {
                item = this.AccountRepository.Get(id.Value);
            }

            if (item == null )
            {
                item = new Account();
            }
    
            return JsonSuccess(item);
        }

        public ActionResult List(AccountQuery query)
        {
            var list = this.AccountRepository.GetList(query);
            var data = list.Data.Select(c => AccountModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(Account obj)
        {
            if (obj.Id > 0)
            {
                obj = this.AccountRepository.Get(obj.Id);
                TryUpdateModel(obj);
            }
            obj = this.AccountRepository.SaveOrUpdate(obj);
            return JsonSuccess(obj);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.AccountRepository.Get(id);

                this.AccountRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }
        
    }

    public class AccountModel
    {
        public int Id { get; set; }

        public String CodeNo { get; set; }

        public String Name { get; set; }

        public Decimal CurAmount { get; set; }

        public Decimal BaseAmount { get; set; }

        public String Note { get; set; }

        public String CreateTimeString { get; set; }

        public AccountModel(Account account)
        {
            this.Id = account.Id;
            this.CodeNo = account.CodeNo;
            this.Name = account.Name;
            this.CurAmount = account.CurAmount;
            this.BaseAmount = account.BaseAmount;
            this.Note = account.Note;
            this.CreateTimeString = account.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static AccountModel From(Account account)
        {
            return new AccountModel(account);
        }
    }
}