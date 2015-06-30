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
    public class CustomerController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Customer item = null;

            if (id.HasValue)
            {
                item = this.CustomerRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new Customer();
            }

            return View(item);
        }

        public ActionResult List(CustomerQuery query)
        {
            var list = this.CustomerRepository.GetList(query);
            var result = new { total = list.RecordCount, rows = list.Data };
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(Customer customer)
        {
            try
            {
                if (customer.Id > 0)
                {
                    customer = this.CustomerRepository.Get(customer.Id);

                    TryUpdateModel(customer);
                }

                if (customer.Pinyin.IsNullOrEmpty() && !customer.Name.IsNullOrEmpty())
                {
                    customer.Pinyin = ChineseToSpell.GetChineseSpell(customer.Name);
                }

                customer = this.CustomerRepository.SaveOrUpdate(customer);

                return JsonSuccess(customer);

            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = CustomerRepository.Get(id);
            if (item != null)
            {
                CustomerRepository.Delete(item);
            }
            
            return JsonSuccess();
        }

        public ActionResult GetCustomer(int id)
        {
            var item = this.CustomerRepository.Get(id);
            if(item == null)
                item = new Customer();
            return JsonSuccess(item);
        }
        
    }
}