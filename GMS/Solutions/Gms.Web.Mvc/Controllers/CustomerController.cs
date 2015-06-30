using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        public ActionResult CreateOrUpdate(Customer customer)
        {
            this.CustomerRepository.SaveOrUpdate(customer);

            return JsonSuccess(customer);
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
            return JsonSuccess(this.CustomerRepository.Get(id));
        }

        public ActionResult GetCustomers(CustomerQuery query)
        {
            return JsonSuccess(this.CustomerRepository.GetAll(query));
        }
        
    }
}