using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gms.Web.Mvc.Controllers.Attribute
{
    public class AuthorizeBaseAttribute : AuthorizeAttribute
    {
        public bool ReturnEmpty { get; set; }
        protected BaseController BaseController { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (ReturnEmpty)
            {
                filterContext.Result = new EmptyResult();
                return;
            }
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = BaseController.JsonNetSuccess(new { _url = FormsAuthentication.LoginUrl });
            }
            else
                base.HandleUnauthorizedRequest(filterContext);

        }
    }
}