using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using PagedList;

namespace ProjektGlowny.Controllers
{
    public class EventsController : Controller
    {
        // GET: Evetns

        public ViewResult Events(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.UserIdSortParm = sortOrder == "UserId" ? "UserId_desc" : "UserId";
                ViewBag.DepartSortParm = sortOrder == "DeparmentId" ? "DeparmentId_desc" : "DeparmentId";
                ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
                ViewBag.NotifDateSortParm = sortOrder == "NotifDate" ? "NotifDate_desc" : "NotifDate";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                EventsModel e = new EventsModel();

                var events = e.GetEvents(new Guid(Session["UserTicket"].ToString()), DateTime.Today.AddDays(-60), DateTime.Today);

                if (!String.IsNullOrEmpty(searchString))
                {
                    events = events.Where(s => s.title.Contains(searchString)
                                           || s.content.Contains(searchString)
                                           || s.departments.Name.Contains(searchString)
                                           || s.Id.ToString().Contains(searchString)
                                           || s.UserId.ToString().Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "id_asc":
                        events = events.OrderBy(s => s.Id);
                        break;
                    case "UserId":
                        events = events.OrderBy(s => s.UserId);
                        break;
                    case "UserId_desc":
                        events = events.OrderByDescending(s => s.UserId);
                        break;
                    case "DeparmentId_desc":
                        events = events.OrderByDescending(s => s.departments.Name);
                        break;
                    case "DeparmentId":
                        events = events.OrderBy(s => s.departments.Name);
                        break;
                    case "Date_desc":
                        events = events.OrderByDescending(s => s.date);
                        break;
                    case "Date":
                        events = events.OrderBy(s => s.date);
                        break;
                    case "NotifDate_desc":
                        events = events.OrderByDescending(s => s.notificationDate);
                        break;
                    case "NotifDate":
                        events = events.OrderBy(s => s.notificationDate);
                        break;
                    default:  // id ascending 
                        events = events.OrderByDescending(s => s.Id);
                        break;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(events.ToPagedList(pageNumber, pageSize));
            }

            RedirectToAction("Login", "login");
            return View();
        }

     
        public ActionResult EventsEdit(int? id)
        {
            if (Session["UserTicket"] != null)
            {
                if (id != null)
                {
                    EventsModel model = new EventsModel();
                    //find
                    return View(model);
                }
                return Redirect("~/Events/Events");
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult EventsEdit(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                //edit func
                return Redirect("~/Messages/Messages");
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult EventsDelete(int? id)
        {
            if (Session["UserTicket"] != null)
            {
                EventsModel model = new EventsModel();

                //find DataCommandService.find()
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult MessagesDelete(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                //delete func
                return Redirect("~/Events/Events");
            }
            return Redirect("~/Login/Login");
        }

        //public ActionResult EventsAdd()
        //{
        //    if (Session["UserTicket"] != null)
        //    {
        //        DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
        //        var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString())); // tu get deparmen

        //        var msgAdd = new MEventsModel
        //        {
        //            departmentsList = departments.Select(d => new SelectListItem
        //            {
        //                Text = d.Department.Name,
        //                Value = d.Id.ToString()
        //            })
        //        };
        //        return View(msgAdd);

        //    }
        //    return Redirect("~/Login/Login");

        //}

        [HttpPost]
        public ActionResult MessagesAdd(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
               //add func from model

                return Redirect("~/Events/Eventss");
            }

            return Redirect("~/Login/Login");
        }
    }
}