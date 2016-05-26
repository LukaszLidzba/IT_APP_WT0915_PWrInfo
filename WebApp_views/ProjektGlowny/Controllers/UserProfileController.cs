using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;

namespace ProjektGlowny.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult UserProfile()
        {
            if (Session["UserTicket"] != null)
            {
                UserModels u = new UserModels();

                UserModels user = u.GetUser(new Guid(Session["UserTicket"].ToString()));

                return View(user);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult ChangePassword(UserModels model)
        {
            if (model.Password == model.repeatPassword)//to do
            {
                return Redirect("~/PWrInfo/Index");
            }
            return Redirect("~/Login/Login");
        }
    }
}