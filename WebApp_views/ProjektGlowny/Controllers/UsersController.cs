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
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                var units = dataQueryService.GetUnits(new Guid(Session["UserTicket"].ToString()));

                var userAdd = new UserModels
                {
                    unitList = units.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    })
                };
 
                return View(userAdd);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UsersAdd(UserModels model)
        {
            if (model.Password == model.repeatPassword)
            {
                model.addUser(new Guid(Session["UserTicket"].ToString()), model.name, model.surname, model.Password, model.Login, model.selectedUnitId, model.isAdmin);

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