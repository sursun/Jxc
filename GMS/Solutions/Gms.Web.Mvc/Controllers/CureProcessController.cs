using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gms.Domain;
using Gms.Infrastructure;
using NHibernate.Criterion;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    [HandleError]
    [Authorize]
    public class CureProcessController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var cureProcess = this.CureProcessRepository.Get(id);
            return View(cureProcess!=null?cureProcess:new CureProcess());
        }
        
        public ActionResult List()
        {
            var list = this.CureProcessRepository.GetAll();
            var result = new { total = list.Count, rows = list };
            return Json(result);
        }

        [Transaction]
        public ActionResult SaveOrUpdate(CureProcess cureProcess, int[] relCureTypes)
        {
            try
            {
                if (relCureTypes == null)
                {
                    throw new Exception("至少选择一个加工类型");
                }

                if (cureProcess.Id > 0)
                {
                    cureProcess = this.CureProcessRepository.Get(cureProcess.Id);

                    TryUpdateModel(cureProcess);
                }

                if (cureProcess.CureTypes == null)
                {
                    cureProcess.CureTypes = new List<CommonCode>();
                }
                
                cureProcess.CureTypes.Clear();
                foreach (var cureTypeId in relCureTypes)
                {
                    cureProcess.CureTypes.Add(this.CommonCodeRepository.Get(cureTypeId));
                }
                
                this.CureProcessRepository.SaveOrUpdate(cureProcess);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }

        [Transaction]
        public ActionResult Delete(int id)
        {
            try
            {
                var cureProcess = this.CureProcessRepository.Get(id);
                this.CureProcessRepository.Delete(cureProcess);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }

        public ActionResult Select()
        {
            return View();
        }
        
        
        //#region 玻璃厚度

        //public ActionResult ThicknessList()
        //{
        //    var list = new List<object>();
        //    var valueList = Enum.GetValues(typeof (Thickness));
        //    foreach (var item in valueList)
        //    {
        //        list.Add(new { valueId = item, valueName = ((Thickness)item).ToString() });
        //    }

        //    return Json(list);
        //}

        //#endregion
    }
}