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

        public ViewResult Events(string sortOrder, string currentFilter, string startDate, string endDate, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.UserIdSortParm = sortOrder == "UserId" ? "UserId_desc" : "UserId";
                ViewBag.DepartSortParm = sortOrder == "DeparmentId" ? "DeparmentId_desc" : "DeparmentId";
                ViewBag.DateSortParm = sortOrder == "Date" ? "Date_desc" : "Date";
                ViewBag.NotifDateSortParm = sortOrder == "NotifDate" ? "NotifDate_desc" : "NotifDate";

                if (startDate == null)
                {
                    startDate = DateTime.Today.AddDays(-15).ToString("MM-dd-yyyy");

                }

                if (endDate == null)
                {
                    endDate = DateTime.Today.AddDays(30).ToString("MM-dd-yyyy");
                }


                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;
                ViewBag.startDate = startDate.ToString();
                ViewBag.endDate = endDate.ToString();
             

                EventsModel e = new EventsModel();

                var events = e.GetEvents(new Guid(Session["UserTicket"].ToString()), DateTime.Parse(startDate), DateTime.Parse(endDate));

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

     
        public ActionResult EventsEdit(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();

                var evnt = dataQueryService.GetEvent(id, new Guid(Session["UserTicket"].ToString()));
                var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString())); // tu get deparmen

                var model = new EventsModel
                {
                    departmentsList = departments.Select(d => new SelectListItem
                    {
                        Text = d.Department.Name,
                        Value = d.Id.ToString()
                    })
                };

                model.Id = evnt.Id;
                model.content = evnt.Content;
                model.title = evnt.Title;
                model.date = DateTime.Parse(evnt.Date);
                model.notificationDate = DateTime.Parse(evnt.NotificationDate);
                model.selectedDepartmentId = evnt.Department.Id;
                model.UserId = evnt.UserId;

                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult EventsEdit(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                if (model.date != null && model.notificationDate != null && model.title != null && model.content != null)
                {
                    model.UserId = (int)Session["UserId"];
                    model.editEvent(model, new Guid(Session["UserTicket"].ToString()));

                    return Redirect("~/Events/Events");
                }
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult EventsDelete(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                EventsModel model = new EventsModel();

                var evnt = dataQueryService.GetEvent(id, new Guid(Session["UserTicket"].ToString()));

                if (evnt != null)
                {
                    model.Id = evnt.Id;
                    model.date = DateTime.Parse(evnt.Date);
                    model.notificationDate = DateTime.Parse(evnt.NotificationDate);
                    model.content = evnt.Content;
                    model.title = evnt.Title;
                    model.departments = evnt.Department;
                    model.UserId = evnt.UserId;

                    return View(model);
                }
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult EventsDelete(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.deleteEvent(model, new Guid(Session["UserTicket"].ToString()));
                return Redirect("~/Events/Events");
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult EventsAdd()
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString())); // tu get deparmen

                var model = new EventsModel
                {
                    departmentsList = departments.Select(d => new SelectListItem
                    {
                        Text = d.Department.Name,
                        Value = d.Id.ToString()
                    })
                };
                return View(model);

            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult EventsAdd(EventsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                if (model.date != null && model.notificationDate != null && model.title != null && model.content != null)
                {
                    model.addEvent(model, new Guid(Session["UserTicket"].ToString()));

                    return Redirect("~/Events/Events");
                }
                return View(model);

            }

            return Redirect("~/Login/Login");
        }
    }
}