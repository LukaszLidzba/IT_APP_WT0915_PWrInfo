using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using ProjektGlowny.LoginService1;

namespace ProjektGlowny.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult UserProfile()
        {
            if (Session["UserTicket"] != null)
            {
                UserModels model = new UserModels();

                model = model.GetUser(new Guid(Session["UserTicket"].ToString()));

                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UserProfile(UserModels model)
        {
            if (Session["UserTicket"] != null)
            {
                if (model.Password == model.repeatPassword)
                {
                    ILoginService loginService = new LoginServiceClient();


                    if (loginService.TryLogin(model.Login.Trim(), model.oldPassword.Trim()))
                    {
                        model.changePassword(model, new Guid(Session["UserTicket"].ToString()));
                        return Redirect("~/PWrInfo/Index");
                    }
                }
                ModelState.AddModelError("", "The user old password is incorrect.");
                return View(model);
               
            }
            return Redirect("~/Login/Login");
        }
    }
}