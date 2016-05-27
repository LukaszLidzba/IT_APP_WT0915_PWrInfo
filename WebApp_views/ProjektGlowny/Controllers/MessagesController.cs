using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using PagedList;

namespace ProjektGlowny.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ViewResult Messages(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.UserIdSortParm = sortOrder == "UserId" ? "UserId_desc" : "UserId";
                ViewBag.DepartmentSortParm = sortOrder == "DeparmentId" ? "DeparmentId_desc" : "DeparmentId";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;
           
                MessagesModel m = new MessagesModel();
           
                var messages = m.GetMessages(new Guid(Session["UserTicket"].ToString()));
                        
                if (!String.IsNullOrEmpty(searchString))
                {
                    messages = messages.Where(s => s.title.Contains(searchString)
                                           || s.content.Contains(searchString)
                                           || s.departments.Name.Contains(searchString)
                                           || s.Id.ToString().Contains(searchString)
                                           || s.UserId.ToString().Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "id_asc":
                        messages = messages.OrderBy(s => s.Id);
                        break;
                    case "UserId":
                        messages = messages.OrderBy(s => s.UserId);
                        break;
                    case "UserId_desc":
                        messages = messages.OrderByDescending(s => s.UserId);
                        break;
                    case "DeparmentId_desc":
                        messages = messages.OrderByDescending(s => s.departments.Name);
                        break;
                    case "DeparmentId":
                        messages = messages.OrderBy(s => s.departments.Name);
                        break;
                    default:  // id ascending 
                        messages = messages.OrderByDescending(s => s.Id);
                        break;
                }

                int pageSize = 5;
                int pageNumber = (page ?? 1);
                return View(messages.ToPagedList(pageNumber, pageSize));
           }
            
            RedirectToAction("Login", "login");
            return View();
        }



        public ActionResult MessagesEdit(int? id)
        {
            if (Session["UserTicket"] != null)
            {
                if (id != null)
                {
                    MessagesModel m = new MessagesModel();
                    
                    return View(m);
                }
                return Redirect("~/Messages/Messages");
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult MessagesEdit(MessagesModel model)
        {
            if (Session["UserTicket"] != null)
            {

                return Redirect("~/Messages/Messages");
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult MessagesDelete(MessagesModel model)
        {
            if (Session["UserTicket"] != null)
            {
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        //[HttpPost]
        //public ActionResult MessagesDelete(MessagesModel model)
        //{
        //    if (Session["UserTicket"] != null)
        //    {
        //        return View();
        //    }
        //    return Redirect("~/Login/Login");
        //}

        public ActionResult MessagesAdd()
        {
            if (Session["UserTicket"] != null)
            {                 
                DataQueryService.IDataQueryService  dataQueryService = new DataQueryService.DataQueryServiceClient();
                var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString())); // tu get deparmen
                
                var msgAdd = new MessagesModel
                {
                    departmentsList = departments.Select(d => new SelectListItem
                    {
                        Text = d.Department.Name,
                        Value = d.Id.ToString()
                    })
                 };
                 return View(msgAdd);

            }
            return Redirect("~/Login/Login");
           
        }

        [HttpPost]
        public ActionResult MessagesAdd(MessagesModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.addMessage(model, new Guid(Session["UserTicket"].ToString()));

                return Redirect("~/Messages/Messages");
            }

            return Redirect("~/Login/Login");
        }
    }
}