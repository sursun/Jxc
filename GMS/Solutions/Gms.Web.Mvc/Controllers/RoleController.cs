using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using Gms.Domain;
using Gms.Infrastructure;
using SecurityGuard.Services;
using SecurityGuard.Interfaces;
using SecurityGuard.ViewModels;
using Gms.Web.Mvc.Controllers;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{

    [HandleError]
    [Authorize]
    public class RoleController : BaseController
    {
 
        #region ctors

        private readonly IRoleService roleService;

        public RoleController()
        {
            this.roleService = new RoleService(Roles.Provider);
        }

        #endregion

        public virtual ActionResult Index()
        {
            ManageRolesViewModel model = new ManageRolesViewModel();
            model.Roles = new SelectList(roleService.GetAllRoles());
            model.RoleList = roleService.GetAllRoles();

            return View(model);
        }

        public virtual ActionResult RoleAuth()
        {
            return View();
        }


        public virtual ActionResult RoleList()
        {
            var roles = roleService.GetAllRoles();

            IList<RoleModel> datas = new List<RoleModel>();
           

            foreach (var role in roles)
            {
                datas.Add(new RoleModel(){RoleName = role});
            }
    
         
            var result = new { total = roles.Length, rows = datas };

            return Json(result);
        }

        //public virtual ActionResult GetRoleAuths(string rolename)
        //{
        //    IList<AuthViewModel> datas = new List<AuthViewModel>();

        //    Array authTypes = Enum.GetValues(typeof (AuthType));
        //    foreach (var authType in authTypes)
        //    {
        //        FillDataFrom(datas, (AuthType)authType, rolename);
        //    }

        //    return Json(new { total = datas.Count, rows = datas });
        //}

        //private void FillDataFrom( IList<AuthViewModel> datas,AuthType authType,string rolename)
        //{
        //    RoleAuth roleAuth = this.RoleAuthRepository.GetBy(rolename, (AuthType)authType);

        //    string group = Enum.GetName(typeof(AuthType), authType);

        //    switch (authType)
        //    {
        //        case AuthType.角色管理:
        //            {
        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.添加);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.删除);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.修改);
        //            }
        //            break;
        //        case AuthType.用户管理:
        //            {
        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.添加);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.删除);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.修改);
        //            }
        //            break;
        //        case AuthType.客户管理:
        //            {
        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.添加);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.删除);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.修改);
        //            }
        //            break;
        //        case AuthType.订单管理:
        //            {
        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.添加);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.删除);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.修改);
        //            }
        //            break;
        //        case AuthType.日志管理:
        //            {
        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.添加);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.删除);

        //                AddData2List(datas, rolename, group, roleAuth, ActionPoint.修改);
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //public void AddData2List(IList<AuthViewModel> datas,string rolename, string group, RoleAuth roleAuth, ActionPoint actionPoint)
        //{
            
        //    string strGroup = group;
        //    string strValue = "";
        //    string strName = Enum.GetName(typeof(ActionPoint), actionPoint);

        //    if (this.RoleAuthRepository.IsAuthorized(roleAuth, actionPoint))
        //    {
        //        strValue = "允许";
        //    }
        //    datas.Add(new AuthViewModel(rolename, strGroup, strName, strValue));
        //}

        //[Transaction]
        //public ActionResult ChangeRoleAuth(string role,string authType,string actionPoint,bool bFlag)
        //{
        //    AuthType aType = (AuthType) Enum.Parse(typeof (AuthType), authType);
        //    RoleAuth roleAuth = this.RoleAuthRepository.GetBy(role,aType);

        //    if (roleAuth == null)
        //    {
        //        roleAuth = new RoleAuth();
        //        roleAuth.Role = role;
        //        roleAuth.AuthType = aType;
        //    }

        //    ActionPoint point = (ActionPoint) Enum.Parse(typeof (ActionPoint), actionPoint);

        //    if (bFlag)
        //    {
        //        int n = (int) point;
        //        roleAuth.Auths = (roleAuth.Auths | (int)point);
        //    }
        //    else
        //    {
        //        roleAuth.Auths = (roleAuth.Auths & (~((int) point)));
        //    }

        //    this.RoleAuthRepository.SaveOrUpdate(roleAuth);

        //    return JsonSuccess();
        //}


        //#region Create Roles Methods

        ////[HttpGet]
        ////public virtual ActionResult CreateRole()
        ////{
        ////    return View(new RoleViewModel());
        ////}

        //[HttpPost]
        //public virtual ActionResult CreateRole(string roleName)
        //{
        //    JsonResponse response = new JsonResponse();

        //    if (string.IsNullOrEmpty(roleName))
        //    {
        //        response.Success = false;
        //        response.Message = "You must enter a role name.";
        //        response.CssClass = "red";

        //        return Json(response);
        //    }

        //    try
        //    {
        //        roleService.CreateRole(roleName);

        //        if (Request.IsAjaxRequest())
        //        {
        //            response.Success = true;
        //            response.Message = "Role created successfully!";
        //            response.CssClass = "green";

        //            return Json(response);
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        if (Request.IsAjaxRequest())
        //        {
        //            response.Success = false;
        //            response.Message = ex.Message;
        //            response.CssClass = "red";

        //            return Json(response);
        //        }

        //        ModelState.AddModelError("", ex.Message);
        //    }

        //    return RedirectToAction("Index");
        //}

        //#endregion

        //#region Delete Roles Methods

        ///// <summary>
        ///// This is an Ajax method.
        ///// </summary>
        ///// <param name="roleName"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public virtual ActionResult DeleteRole(string roleName)
        //{
        //    JsonResponse response = new JsonResponse();

        //    if (string.IsNullOrEmpty(roleName))
        //    {
        //        response.Success = false;
        //        response.Message = "You must select a Role Name to delete.";
        //        response.CssClass = "red";

        //        return Json(response);
        //    }

        //    roleService.DeleteRole(roleName);

        //    response.Success = true;
        //    response.Message = roleName + " was deleted successfully!";
        //    response.CssClass = "green";

        //    return Json(response);


        //}

        //public virtual ActionResult Delete(string roleName)
        //{

        //    if (string.IsNullOrEmpty(roleName))
        //    {
        //        return JsonError("请选择要删除的角色");
        //    }

        //    roleService.DeleteRole(roleName);

        //    return JsonSuccess();


        //}
        //[HttpPost]
        //public ActionResult DeleteRoles(string roles, bool throwOnPopulatedRole)
        //{
        //    JsonResponse response = new JsonResponse();
        //    response.Messages = new List<ResponseItem>();

        //    if (string.IsNullOrEmpty(roles))
        //    {
        //        response.Success = false;
        //        response.Message = "You must select at least one role.";
        //        return Json(response);
        //    }

        //    string[] roleNames = roles.Split(',');
        //    StringBuilder sb = new StringBuilder();

        //    ResponseItem item = null;

        //    foreach (var role in roleNames)
        //    {
        //        if (!string.IsNullOrEmpty(role))
        //        {
        //            try
        //            {
        //                roleService.DeleteRole(role, throwOnPopulatedRole);

        //                item = new ResponseItem();
        //                item.Success = true;
        //                item.Message = "Deleted this role successfully - " + role;
        //                item.CssClass = "green";
        //                response.Messages.Add(item);

        //                //sb.AppendLine("Deleted this role successfully - " + role + "<br />");
        //            }
        //            catch (System.Configuration.Provider.ProviderException ex)
        //            {
        //                //sb.AppendLine(role + " - " + ex.Message + "<br />");

        //                item = new ResponseItem();
        //                item.Success = false;
        //                item.Message = ex.Message;
        //                item.CssClass = "yellow";
        //                response.Messages.Add(item);
        //            }
        //        }
        //    }

        //    response.Success = true;
        //    response.Message = sb.ToString();

        //    return Json(response);
        //}

        //#endregion

        //#region Get Users In Role methods

        ///// <summary>
        ///// This is an Ajax method that populates the 
        ///// Roles drop down list.
        ///// </summary>
        ///// <returns></returns>
        //public ActionResult GetAllRoles()
        //{
        //    var list = roleService.GetAllRoles();

        //    List<SelectObject> selectList = new List<SelectObject>();

        //    foreach (var item in list)
        //    {
        //        selectList.Add(new SelectObject() { caption = item, value = item });
        //    }

        //    return Json(selectList, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult GetUsersInRole(string roleName)
        //{
        //    var list = roleService.GetUsersInRole(roleName);

        //    return Json(list, JsonRequestBehavior.AllowGet);
        //}


        //#endregion
    }

    public class RoleModel
    {
        public string RoleName { get; set; }
    }

    public class AuthViewModel
    {
        public AuthViewModel()
        {
            
        }

        public AuthViewModel(string role,string group,string name,string value)
        {
            this.role = role;
            this.group = group;
            this.name = name;
            this.value = value;
        }

        public string role { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string group { get; set; }
    }
}
