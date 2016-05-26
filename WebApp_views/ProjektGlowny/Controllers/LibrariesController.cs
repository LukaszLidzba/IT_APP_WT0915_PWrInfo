using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
    public class LibrariesController : Controller
    {
        // GET: Libraries

        public ActionResult Libraries()
        {
            return View();
        }

        public ActionResult LibrariesEdit()
        {
            return View();
        }
    }
}