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

        public ActionResult Libraries()
        {
            return View();
        }
        public ActionResult Data()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Messages()
        {
            return View();
        }
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            return View();
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

              //  return View(Messages);

            }
            return Redirect("~/Login/Login");
        }
    }
}