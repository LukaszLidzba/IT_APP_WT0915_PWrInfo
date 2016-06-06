using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using ProjektGlowny.LoginService1;
using ProjektGlowny.DataQueryService;
using System.Web.Security;

namespace ProjektGlowny.Controllers
{
    public class LoginController : Controller
    {
        // GET: User
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(UserModels model)
        {
            ILoginService loginService = new LoginServiceClient();

            try
            {
                var result = loginService.Login(model.Login.Trim(), FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1"));

                var user = loginService.GetUser(new Guid(result));

                Session["UserTicket"] = result;
                Session["UserName"] = user.Name;
                Session["UserSurname"] = user.Surname;
                Session["UserId"] = user.Id;
                Session["UserIsAdmin"] = user.IsAdmin.ToString();

                return Redirect("~/PWrInfo/Index");
            }
            catch (Exception ex)
            {
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        //
        // POST: /Account/LogOff
        public ActionResult LogOff()
        {
            Session.Abandon();
            return Redirect("~/Login/Login");
        }


        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        #endregion
    }
}