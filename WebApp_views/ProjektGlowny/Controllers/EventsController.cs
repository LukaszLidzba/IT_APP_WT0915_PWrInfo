using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
    public class EventsController : Controller
    {
        // GET: Evetns

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult EventsEdit()
        {
            return View();
        }
    }
}