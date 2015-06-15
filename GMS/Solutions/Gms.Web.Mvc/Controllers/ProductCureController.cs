using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Internal;
using Gms.Domain;
using Gms.Infrastructure;
using SharpArch.NHibernate.Web.Mvc;
using Newtonsoft.Json;

namespace Gms.Web.Mvc.Controllers
{
    [HandleError]
    [Authorize]
    public class ProductCureController : BaseController
    {
        public ActionResult List(ProductCureQuery query)
        {
            var list = this.ProductCureRepository.GetList(query);
            var data = list.Data.Select(c => ProductCureModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        public ActionResult Edit(int id,int? orderid)
        {
            var productcure = this.ProductCureRepository.Get(id);

            if (productcure == null && orderid.HasValue)
            {
                productcure = new ProductCure();
                productcure.Order = this.OrderRepository.Get(orderid.Value);
            }

            return View(productcure);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(ProductCure productcure)
        {
            if (productcure.Id > 0)
            {
                productcure = this.ProductCureRepository.Get(productcure.Id);

                TryUpdateModel(productcure);
            }

            this.ProductCureRepository.SaveOrUpdate(productcure);
            return JsonSuccess();
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var productcure = this.ProductCureRepository.Get(id);
            
                this.ProductCureRepository.Delete(productcure);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

    }

    public class ProductCureModel
    {
        public ProductCureModel(ProductCure productCure)
        {
            this.OrderCodeNo = productCure.Order.CodeNo;
            this.CureTypeName = productCure.CureType.Name;
            this.UserName = productCure.User == null ? "" : productCure.User.LoginName;
            this.CheckUserName = productCure.CheckUser == null ? "" : productCure.CheckUser.LoginName;
            this.StartTimeString = productCure.StartTime.ToString("yyyy-MM-dd");
            this.EndTimeString = productCure.EndTime.ToString("yyyy-MM-dd");
            this.Note = productCure.Note;

        }

        /// <summary>
        /// 订单编号
        /// </summary>  
        public String OrderCodeNo { get; set; }

        /// <summary>
        /// 加工类型
        /// </summary>
        public String CureTypeName { get; set; }

        /// <summary>
        /// 加工人员
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 质检员（车间主任）
        /// </summary>
        public String CheckUserName { get; set; }

        /// <summary>
        /// 开始加工时间（领单日期）
        /// </summary>
        public String StartTimeString { get; set; }

        /// <summary>
        /// 结束加工时间（交单日期）
        /// </summary>
        public String EndTimeString { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public static ProductCureModel From(ProductCure productCure)
        {
            return new ProductCureModel(productCure);
        }
    }

}