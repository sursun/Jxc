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
    public class DepartmentController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

 

        public ActionResult Select()
        {
            return View();
        }

        public ActionResult Edit(int? id, int? parentid)
        {
            Department item = null;
 
            if (id.HasValue)
            {
                item = this.DepartmentRepository.Get(id.Value);
            }

            if (item == null && parentid.HasValue)
            {
                item = new Department();
                item.Parent = this.DepartmentRepository.Get(parentid.Value);
            }
    
            return View(item);
        }
        

        [Transaction]
        public ActionResult SaveOrUpdate(Department obj)
        {
            if (obj.Id > 0)
            {
                obj = this.DepartmentRepository.Get(obj.Id);
                TryUpdateModel(obj);
            }
            obj = this.DepartmentRepository.SaveOrUpdate(obj);
            return JsonSuccess(obj);
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var obj = this.DepartmentRepository.Get(id);

                this.DepartmentRepository.Delete(obj);

                return JsonSuccess();
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }

        public ActionResult GetData(int? id)
        {
            IList<Department> list = null;
            if (!id.HasValue)
            {
                list = this.DepartmentRepository.GetRoot();
            }
            else
            {
                list = this.DepartmentRepository.GetChildren(id.Value);
            }

            IList<DepartmentModel> data = null;

            if (list != null)
            {
                data = list.Select(c => DepartmentModel.From(c)).ToList();
            }

            return Json(data);
        }


    }

    public class DepartmentModel
    {
        public int Id { get; set; }

        public int ParentId { get; set; }

        public String CodeNo { get; set; }

        public String Name { get; set; }

        public int Level { get; set; }

        public String Note { get; set; }

        public bool isLoaded
        {
            get { return false; }
        }

        public String state
        {
            get { return "closed"; }
        }

        public DepartmentModel(Department department)
        {
            this.Id = department.Id;
            this.ParentId = 0;
            if (department.Parent != null)
                this.ParentId = department.Parent.Id;
            this.Name = department.Name;
            this.CodeNo = department.CodeNo;
            this.Level = department.Level;
            this.Note = department.Note;
        }

        public static DepartmentModel From(Department department)
        {
            return new DepartmentModel(department);
        }
    }
}