using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;

namespace ProjektGlowny.Controllers
{
    public class UsersController : Controller
    {
        
        
        public ActionResult UsersAdd()
        {
            UserModels model = new UserModels();
            return View(model);
        }

        [HttpPost]
        public ActionResult UsersAdd(UserModels model)
        {
            if (model.Password == model.repeatPassword)
            {
                model.addUser(new Guid(Session["UserTicket"].ToString()), model.name, model.surname, model.Password, model.Login, 1, model.isAdmin);

                return Redirect("~/Users/Users");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        // GET: Users
        public ActionResult Users()
        {
            if (Session["UserTicket"] != null)
            {
                UserModels u = new UserModels();

                IList<UserModels> users = u.GetUsers(new Guid(Session["UserTicket"].ToString())).ToList();

                return View(users);
            }
            return Redirect("~/Login/Login");
        }
    }
}