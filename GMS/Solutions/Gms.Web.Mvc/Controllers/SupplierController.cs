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
    public class SupplierController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Select()
        {
            return View();
        }

        public ActionResult Alert()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            Supplier item = null;

            if (id.HasValue)
            {
                item = this.SupplierRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new Supplier();
            }

            return View(item);
        }

        public ActionResult List(SupplierQuery query)
        {
            var list = this.SupplierRepository.GetList(query);
            var data = list.Data.Select(c => SupplierModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(Supplier supplier)
        {
            try
            {
                if (supplier.Id > 0)
                {
                    supplier = this.SupplierRepository.Get(supplier.Id);

                    TryUpdateModel(supplier);
                }

                if (supplier.Pinyin.IsNullOrEmpty() && !supplier.Name.IsNullOrEmpty())
                {
                    supplier.Pinyin = ChineseToSpell.GetChineseSpell(supplier.Name);
                }

                supplier = this.SupplierRepository.SaveOrUpdate(supplier);

                return JsonSuccess(supplier);

            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = SupplierRepository.Get(id);
            if (item != null)
            {
                SupplierRepository.Delete(item);
            }
            
            return JsonSuccess();
        }
        
    }


    public class SupplierModel:RelationPersonModel
    {
        /// <summary>
        /// 供应商类别
        /// </summary>
        public int SupplierTypeId { get; set; }
        public String SupplierTypeString { get; set; }

        /// <summary>
        /// 税号
        /// </summary>
        public String ShuiHao { get; set; }

        /// <summary>
        /// 帐号
        /// </summary>
        public String CardNo { get; set; }

        /// <summary>
        /// 增值税率
        /// </summary>
        public decimal TaxRate { get; set; }

        /// <summary>
        /// 期初应付款
        /// </summary>
        public decimal FukuanQc { get; set; }

        /// <summary>
        /// 应付款
        /// </summary>
        public decimal FukuanYing { get; set; }

        /// <summary>
        /// 预付款
        /// </summary>
        public decimal FukuanYu { get; set; }

        public SupplierModel(Supplier supplier)
            : base(supplier)
        {
            if (supplier.SupplierType != null)
            {
                this.SupplierTypeId = supplier.SupplierType.Id;
                this.SupplierTypeString = supplier.SupplierType.Name;
            }

            this.ShuiHao = supplier.ShuiHao;
            this.CardNo = supplier.CardNo;
            this.TaxRate = supplier.TaxRate;
            this.FukuanQc = supplier.FukuanQc;
            this.FukuanYing = supplier.FukuanYing;
            this.FukuanYu = supplier.FukuanYu;
        }

        public static SupplierModel From(Supplier supplier)
        {
            return new SupplierModel(supplier);
        }

    }
}