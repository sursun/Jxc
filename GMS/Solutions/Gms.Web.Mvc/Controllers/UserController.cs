using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gms.Common;
using Gms.Domain;
using SecurityGuard.ViewModels;
using SharpArch.NHibernate.Web.Mvc;

namespace Gms.Web.Mvc.Controllers
{
    //[HandleError]
    //[Authorize]
    public class UserController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            User item = null;

            if (id.HasValue)
            {
                item = this.UserRepository.Get(id.Value);
            }

            if (item == null)
            {
                item = new User();
            }

            return View(item);
        }


        public ActionResult List(UserQuery query)
        {
            var list = this.UserRepository.GetList(query);
            var result = new { total = list.RecordCount, rows = list.Data };
            return Json(result);
        }

        public ActionResult GetAll()
        {
            var list = this.UserRepository.GetAll();

            var data = list.Select(usr => new 
            {
                label = usr.LoginName,
                value = usr.Id
            }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        } 

        [Transaction]
        public ActionResult SaveOrUpdate(User user, string psw)
        {
            try
            {
                if (user.Id <= 0)
                {
                    string strUserName = user.LoginName.Trim();

                    MembershipUser membershipuser = Membership.GetUser(strUserName);

                    if (membershipuser != null)
                    {
                        throw new Exception("用户[" + strUserName +"]已经存在，请更换登录名!");
                    }

                    membershipuser = Membership.CreateUser(strUserName, psw);

                    user.MemberShipId = (Guid)membershipuser.ProviderUserKey;

                }
                else
                {
                    user = this.UserRepository.Get(user.Id);

                    TryUpdateModel(user);
                }

                if (user.Pinyin.IsNullOrEmpty() && !user.RealName.IsNullOrEmpty())
                {
                    user.Pinyin = ChineseToSpell.GetChineseSpell(user.RealName);
                }

                user = this.UserRepository.SaveOrUpdate(user);

                return JsonSuccess(user);

            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }
        }


        [Transaction]
        public ActionResult Delete(int id)
        {
            var item = UserRepository.Get(id);
            if (item != null)
            {
                Membership.DeleteUser(item.LoginName);

                UserRepository.Delete(item);
            }
            return JsonSuccess();
        }

        public ActionResult GetUser(int id)
        {
            var user = this.UserRepository.Get(id);
            return JsonSuccess(user==null?(new User()):user);
        }

        public ActionResult ResetPassword(int id)
        {
            var user = this.UserRepository.Get(id);
            if (user == null)
                return JsonError("没有找到用户，请刷新后再试！");
            MembershipUser membershipUser = Membership.GetUser(user.LoginName);
            string tempPsw = membershipUser.ResetPassword();
            string defaultPassword = "123";
            try
            {
                membershipUser.ChangePassword(tempPsw, defaultPassword);
            }
            catch (Exception ex)
            {
                return JsonError(ex.Message);
            }

            return JsonSuccess(defaultPassword);
        }

        public virtual ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception ex)
                {
                    return JsonError(ex.Message);
                }

                return JsonSuccess();
            }

            return JsonError("");
        }
    }
}