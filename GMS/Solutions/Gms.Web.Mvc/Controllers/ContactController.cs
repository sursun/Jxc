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
    public class ContactController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult List(ContactQuery query)
        {
            var list = this.ContactRepository.GetList(query);
            var data = list.Data.Select(c => ContactModel.From(c)).ToList();
            var result = new { total = list.RecordCount, rows = data};
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(Contact contact)
        {
            try
            {
                if (contact.Id > 0)
                {
                    contact = this.ContactRepository.Get(contact.Id);

                    TryUpdateModel(contact);
                }

                contact = this.ContactRepository.SaveOrUpdate(contact);

                return JsonSuccess(contact);

            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = this.ContactRepository.Get(id);
            if (item != null)
            {
                this.ContactRepository.Delete(item);
            }
            
            return JsonSuccess();
        }

        public ActionResult GetContact(int id)
        {
            var item = this.ContactRepository.Get(id);
            if (item == null)
            {
                item = new Contact();
            }
            return JsonSuccess(item);
        }
        
    }

    public class ContactModel
    {
        public int Id { get; set; }

        /// <summary>
        /// 所属联系人
        /// </summary>
        public String RelationPersonName { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public String Gender { get; set; }

        /// <summary>
        /// 证件号码
        /// </summary>
        public String CardNo { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public String BirthdayString { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public String Mobile { get; set; }

        /// <summary>
        /// QQ号码
        /// </summary>
        public String QQ { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public String Address { get; set; }

        /// <summary>
        /// 是否为默认联系方式？
        /// </summary>
        public String IsDefault { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public String Note { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public String CreateTimeString { get; set; }

        public ContactModel(Contact contact)
        {
            this.Id = contact.Id;
            if (contact.RelationPerson != null)
            {
                this.RelationPersonName = contact.RelationPerson.Name;
            }
            this.Name = contact.Name;
            this.Gender = contact.Gender.ToString();
            this.CardNo = contact.CardNo;
            this.BirthdayString = contact.Birthday.ToString("yyyy-MM-dd HH:mm:ss");
            this.Mobile = contact.Mobile;
            this.QQ = contact.QQ;
            this.Email = contact.Email;
            this.Address = contact.Address;
            this.IsDefault = contact.IsDefault.ToString();
            this.Note = contact.Note;
            this.CreateTimeString = contact.CreateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static ContactModel From(Contact contact)
        {
            return new ContactModel(contact);
        }
    }
}