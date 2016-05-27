using ProjektGlowny.DataQueryService;
using ProjektGlowny.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
  public class PWrInfoController : Controller
  {
    // GET: PWrInfo
    public ActionResult Index()
    {
      if (Session["UserTicket"] != null)
      {
        MessagesModel m = new MessagesModel();
        EventsModel e = new EventsModel();

        var tuple = new Tuple<List<MessagesModel>, List<EventsModel>>
            (m.GetMessages(new Guid(Session["UserTicket"].ToString())).OrderByDescending(msg => msg.Id).ToList(), e.GetEvents(new Guid(Session["UserTicket"].ToString())).OrderByDescending(evt => evt.Id).ToList());

        return View(tuple);
      }
      return Redirect("~/Login/Login");
    }

    public ActionResult Data()
    {
      return View();
    }
 
  }
}