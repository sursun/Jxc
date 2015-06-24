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
    public class CommonCodeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TypeInfo(CommonCodeType type)
        {
            String viewName = "TypeInfo";

            viewName += ParseExtName(type);

            return View(viewName,type);
        }

        public ActionResult Select(CommonCodeType type)
        {
            String viewName = "Select";

            viewName += ParseExtName(type);

            return View(viewName, type);
        }

        public ActionResult Edit(int? id, int? parentid, CommonCodeType? type)
        {
            CommonCode item = null;
            String viewName = "Edit";

            if (id.HasValue)
            {
                item = this.CommonCodeRepository.Get(id.Value);
            }

            if (item == null && parentid.HasValue && type.HasValue)
            {
                item = new CommonCode();
                item.Type = type.Value;
                item.Parent = this.CommonCodeRepository.Get(parentid.Value);
            }

            if (item != null)
            {
                viewName += ParseExtName(item.Type);
            }
            
            return View(viewName,item);
        }

        public String ParseExtName(CommonCodeType type)
        {
            String strRet = "";

            if (type == CommonCodeType.客户等级)
            {
                strRet = "Khdj";
            }
            
            return strRet;
        }

        [Transaction]
        public ActionResult SaveOrUpdate(CommonCode obj)
        {
            if (obj.Id > 0)
            {
                obj = this.CommonCodeRepository.Get(obj.Id);
                TryUpdateModel(obj);
            }
            obj = this.CommonCodeRepository.SaveOrUpdate(obj);
            return JsonSuccess(obj);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.CommonCodeRepository.Get(id);

                this.CommonCodeRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        public ActionResult GetData(int? id, CommonCodeType type)
        {
            IList<CommonCode> list = null;
            if (!id.HasValue)
            {
                list = this.CommonCodeRepository.GetRoot(type);
            }
            else
            {
                list = this.CommonCodeRepository.GetChildren(id.Value);
            }

            IList<CommonCodeModel> data = null;

            if (list != null)
            {
                data = list.Select(c => CommonCodeModel.From(c)).ToList();
            }

            return Json(data);
        }


    }

    public class CommonCodeModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public String Name { get; set; }

        public String FullName { get; set; }

        public String CodeNo { get; set; }

        public String ParamString { get; set; }

        public Boolean ParamFlag { get; set; }

        public decimal ParamDecimal { get; set; }

        public String Note { get; set; }

        public bool isLoaded
        {
            get { return false; }
        }

        public String state
        {
            get { return "closed"; }
        }

        public CommonCodeModel(CommonCode commonCode)
        {
            this.Id = commonCode.Id;
            this.ParentId = 0;
            if (commonCode.Parent != null)
                this.ParentId = commonCode.Parent.Id;
            this.Name = commonCode.Name;
            this.FullName = commonCode.FullNameString();
            this.CodeNo = commonCode.CodeNo;
            this.ParamString = commonCode.ParamString;
            this.ParamFlag = commonCode.ParamFlag;
            this.ParamDecimal = commonCode.ParamDecimal;

            this.Note = commonCode.Note;
        }

        public static CommonCodeModel From(CommonCode commonCode)
        {
            return new CommonCodeModel(commonCode);
        }
    }
}