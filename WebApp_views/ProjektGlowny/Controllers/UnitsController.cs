using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
    public class UnitsController : Controller
    {
        // GET: Units
        public ActionResult Units()
        {
            return View();
        }

        public ActionResult UnitsEdit()
        {
            return View();
        }
    }
}