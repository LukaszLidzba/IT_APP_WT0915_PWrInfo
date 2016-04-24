using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using ProjektGlowny.LoginService1;

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
        public ActionResult Login(UserModels model, string returnUrl)
        {
            ILoginService loginService = new LoginServiceClient();

            try
            {
                var result = loginService.Login(model.UserName.Trim(), model.Password.Trim());

                Session["UserTicket"] = result; 

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

        [HttpPost]
        public ActionResult LogOff()
        {
            // HERE CLEAN SESSION - GET RID OFF TAKEN!!!  //PZJ 

            return RedirectToAction("Index", "Home");
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