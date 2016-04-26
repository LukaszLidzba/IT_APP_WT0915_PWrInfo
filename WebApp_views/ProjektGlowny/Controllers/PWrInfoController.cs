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
                MessagesModel x = new MessagesModel();
                IList<MessagesModel> Messages = x.GetMessages(new Guid(Session["UserTicket"].ToString())).ToList();
 
                return View(Messages);

            }
            return Redirect("~/Login/Login");
        }
    }
}