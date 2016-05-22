using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using ProjektGlowny.DataQueryService;

namespace ProjektGlowny.Controllers
{
    public class PWrInfoController : Controller
    {
        // GET: PWrInfo

        public ActionResult DeansOfficesEdit()
        {
            return View();
        }
        public ActionResult DeansOffices()
        {
            return View();
        }
        public ActionResult UnitsEdit()
        {
            return View();
        }
        public ActionResult Units()
        {
            return View();
        }
        public ActionResult LibrariesEdit()
        {
            return View();
        }
        public ActionResult Libraries()
        {
            return View();
        }
        public ActionResult Data()
        {
            return View();
        }
        public ActionResult EventsEdit()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult MessagesEdit()
        {
            return View();
        }
        public ActionResult Messages()
        {
            return View();
        }
        public ActionResult UsersEdit()
        {
            UserModels model = new UserModels();
            return View(model);
        }


        [HttpPost]
        public ActionResult UsersEdit(UserModels model)
        {
            if (model.Password == model.repeatPassword)
            {
                model.addUser(new Guid(Session["UserTicket"].ToString()), model.name, model.surname, model.Password, model.Login, 0, true);

                return Redirect("~/PWrInfo/Users");
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

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
      
        public ActionResult Index()
        {
            if(Session["UserTicket"] != null)
            {
                MessagesModel m = new MessagesModel();
                EventsModel e = new EventsModel();
  
                var tuple = new Tuple<List<MessagesModel>, List<EventsModel>>
                    (m.GetMessages(new Guid(Session["UserTicket"].ToString())).ToList(), e.GetEvents(new Guid(Session["UserTicket"].ToString())).ToList());
               
                return View(tuple);

            }
            return Redirect("~/Login/Login");
        }

      
    }
}