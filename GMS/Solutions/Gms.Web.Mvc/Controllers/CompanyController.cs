using System;
using System.Linq.Expressions;
using Gms.Domain;
using Gms.Infrastructure;
using ReginfoRepository;
using SharpArch.NHibernate.Web.Mvc;


namespace Gms.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    [HandleError]
    public class CompanyController : BaseController
    {
        public ActionResult Index()
        {
            var  snlist = ReginfoRepository.Common.GetMachineCode();
            if (snlist != null && snlist.Count>0)
            {
                ViewData["PcSn"] = snlist[0];
            }

            ViewData["LocalRegInfo"] = CurrentRegInfo;
            
            return View();
        }
        
        [Transaction]
        public ActionResult SaveOrUpdate(string regkey)
        {
            try
            {
                RegInfo regInfo = ReginfoRepository.Common.GetKeyInfo(false, regkey);
                var result = ReginfoRepository.Common.ValidRegInfo(regInfo);

                if (!result.IsValid)
                {
                    return JsonError(result.Message);
                }
                
                //判断是否在允许导入范围内
                DateTime tmCurrent = DateTime.Now;

                if (regInfo.ImportEndTime.CompareTo(tmCurrent) < 0)
                {
                    return JsonError("注册码无法导入！");
                }

                if (regInfo.ImportStartTime.CompareTo(tmCurrent) > 0)
                {
                    return JsonError("注册码无法导入！");
                }
                
                Company company = null;
                var list = CompanyRepository.GetAll();
                if (list != null && list.Count > 0)
                {
                    company = list[0];
                }
                if (company == null)
                {
                    company = new Company();
                }

                
                company.CodeNo = regInfo.CompanyCode;
                company.Name = regInfo.CompanyName;
                company.RegKey = regkey;

                CompanyRepository.SaveOrUpdate(company);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess();
        }
    
    }
}
