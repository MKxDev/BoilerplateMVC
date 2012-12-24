using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBaseBootstrap.Services;
using WebBaseBootstrap.Views;

namespace WebBaseBootstrap.Controllers
{
    public class AccountController : BaseController
    {
        public const string Name = "Account";
        public const string LoginAction = "Login";
        public const string LogoutAction = "Logout";
        public const string RegisterAction = "Register";
        public const string LoginPartialAction = "LoginPartial";

        public MembershipService MembershipService { get; set; }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View();
        }
        
        public ActionResult Register(string email, string email2, string password, string password2)
        {
            // TODO: Obviously provider better validation
            if (String.IsNullOrWhiteSpace(email) || String.IsNullOrWhiteSpace(email2) ||
                String.IsNullOrWhiteSpace(password) || String.IsNullOrWhiteSpace(password2) ||
                email != email2 || password != password2)
            {
                return RedirectToAction(AccountController.LoginAction, AccountController.Name);
            }

            MembershipCreateStatus status;
            var user = MembershipService.CreateUser(email, password, email, null, null, true, null, out status);

            if (status == MembershipCreateStatus.Success)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);

                return Redirect("/");
            }

            return RedirectToAction(AccountController.LoginAction, AccountController.Name);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            if (MembershipService.ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);

                return Redirect("/");
            }
            
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("/");
        }

        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView(ViewNames.UserbarPartial);
        }
    }
}
