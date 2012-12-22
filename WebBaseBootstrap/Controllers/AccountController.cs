using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebBaseBootstrap.Services;

namespace WebBaseBootstrap.Controllers
{
    public class AccountController : BaseController
    {
        public const string Name = "Account";
        public const string LoginAction = "Login";
        public const string LogoutAction = "Logout";
        public const string RegisterAction = "Register";

        public MembershipService MembershipService { get; set; }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Login()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(string email, string password, bool rememberMe = false)
        {
            if (MembershipService.ValidateUser(email, password))
            {
                // FormsAuthentication.SetAuthCookie(email, rememberMe);

                return Redirect("/");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("/");
        }
    }
}
