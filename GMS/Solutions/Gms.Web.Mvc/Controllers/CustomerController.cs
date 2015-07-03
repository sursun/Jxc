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

        public ActionResult Alert()
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
            var data = list.Data.Select(c => CustomerModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data };
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

        //public ActionResult GetCustomer(int id)
        //{
        //    var item = this.CustomerRepository.Get(id);
        //    if(item == null)
        //        item = new Customer();
        //    return JsonSuccess(item);
        //}
        
    }

    public class RelationPersonModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 联系人类型
        /// </summary>
        public String RelationTypeName { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public String CodeNo { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 拼音（姓名）
        /// </summary>
        public String Pinyin { get; set; }

        /// <summary>
        /// 默认结算账户
        /// </summary>
        public int AccountId { get; set; }
        public String AccountName { get; set; }

        /// <summary>
        /// 期初日期
        /// </summary>
        public String BaseTimeString { get; set; }

        /// <summary>
        /// 累计金额
        /// 消费（客户）
        /// 采购（供应商）
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 添加日期（开户时间）
        /// </summary>
        public String CreateTimeString { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        public RelationPersonModel(RelationPerson relationPerson)
        {
            this.Id = relationPerson.Id;
            this.RelationTypeName = relationPerson.RelationType.ToString();
            this.CodeNo = relationPerson.CodeNo;
            this.Name = relationPerson.Name;
            this.Pinyin = relationPerson.Pinyin;

            if (relationPerson.Account != null)
            {
                this.AccountId = relationPerson.Account.Id;
                this.AccountName = relationPerson.Account.Name;
            }

            this.BaseTimeString = relationPerson.BaseTime.ToString("yyyy-MM-dd HH:mm:ss dddd");
            this.Amount = relationPerson.Amount;
            this.CreateTimeString = relationPerson.CreateTime.ToString("yyyy-MM-dd HH:mm:ss dddd");
            this.Note = relationPerson.Note;
        }

    }


    public class CustomerModel:RelationPersonModel
    {
        /// <summary>
        /// 客户类型
        /// </summary>
        public int CustomerTypeId { get; set; }
        public String CustomerTypeString { get; set; }

        /// <summary>
        /// 客户等级 
        /// </summary>
        public int CustomerGradeId { get; set; }
        public String CustomerGradeString { get; set; }

        /// <summary>
        /// 期初应收款
        /// </summary>
        public decimal ShoukuanQc { get; set; }

        /// <summary>
        /// 应收款
        /// </summary>
        public decimal ShoukuanYing { get; set; }

        /// <summary>
        /// 预收款
        /// </summary>
        public decimal ShoukuanYu { get; set; }

        /// <summary>
        /// 是否允许欠款
        /// </summary>
        public String AllowDebt { get; set; }

        /// <summary>
        /// 允许欠款金额
        /// </summary>
        public decimal Debt { get; set; }

        /// <summary>
        /// 累计积分
        /// </summary>
        public int Point { get; set; }

        public CustomerModel(Customer customer) : base(customer)
        {
            if (customer.CustomerType != null)
            {
                this.CustomerTypeId = customer.CustomerType.Id;
                this.CustomerTypeString = customer.CustomerType.Name;
            }

            if (customer.CustomerGrade != null)
            {
                this.CustomerGradeId = customer.CustomerGrade.Id;
                this.CustomerGradeString = customer.CustomerGrade.Name;
            }

            this.ShoukuanQc = customer.ShoukuanQc;
            this.ShoukuanYing = customer.ShoukuanYing;
            this.ShoukuanYu = customer.ShoukuanYu;
            this.AllowDebt = customer.AllowDebt.ToString();
            this.Debt = customer.Debt;
            this.Point = customer.Point;
        }

        public static CustomerModel From(Customer customer)
        {
            return new CustomerModel(customer);
        }

    }
}