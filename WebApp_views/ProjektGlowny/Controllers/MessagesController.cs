using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult MessagesEdit()
        {
            return View();
        }
    }
}