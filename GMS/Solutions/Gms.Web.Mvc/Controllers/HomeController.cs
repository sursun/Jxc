namespace Gms.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    [HandleError]
    [Authorize]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //var user = CurrentUser;
            if (CurrentRegInfo == null)
            {
                ViewData["CompanyName"] = "测试公司";
            }
            else
            {
                ViewData["CompanyName"] = CurrentRegInfo.CompanyName;
            }
            
            return View(CurrentUser);
        }
        public ActionResult Welcome()
        {
            return View();
        }

    }
}
