using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TMS.Model;
using TMS.Business.Interface;
using TMS.Business.Logic;
using System.Globalization;

namespace ticketmanagmentsystem.Controllers
{
    public class AccountController : Controller
    {
        private IAccountManager _accountmanager = null;

        public AccountController()
        {
            this._accountmanager = new AccountManager();
        }

        public AccountController(IAccountManager accountmanager)
        {
            this._accountmanager = accountmanager;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
           
                var result=_accountmanager.AuthenticateUser(objLoginModel);
                if (result != null)
                {
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                              1,
                              result.LoginId.ToString(CultureInfo.CurrentCulture),                          //user Name
                              DateTime.Now,
                              DateTime.Now.AddMinutes(30),                          // expiry in 30 min
                              objLoginModel.RememberMe,
                             objLoginModel.UserRole.ToString(CultureInfo.CurrentCulture) + "_" + result.LoginId.ToString());
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                                                       FormsAuthentication.Encrypt(authTicket));
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("DashBoard", "Home");
                }
            else
            {
                ModelState.AddModelError("", "Invalid User");
            }
            return View("Index", objLoginModel);
        }

        public ActionResult UserLogin()
        {

            return View();
        }

        public ActionResult EmployeLogin()
        {

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account", null);
        }

        [HttpPost]
        public ActionResult customerRegistration(LoginModel objmodel)
        {
            if (ModelState.IsValid)
            {
                return View("Completed");
            }
            var result = _accountmanager.CustomerRegistration(objmodel);
            return View();
        }
    }
}