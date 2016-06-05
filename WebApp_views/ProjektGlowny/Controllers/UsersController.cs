using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using PagedList;

namespace ProjektGlowny.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ViewResult Users(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";
                ViewBag.SurnameSortParm = sortOrder == "Surname" ? "Surname_desc" : "Surname";
                ViewBag.LoginSortParm = sortOrder == "Login" ? "Login_desc" : "Login";
                ViewBag.IsAdminSortParm = sortOrder == "IsAdmin" ? "IsAdmin_desc" : "IsAdmin";
                ViewBag.UnitSortParm = sortOrder == "Unit" ? "Unit_desc" : "Unit";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                UserModels m = new UserModels();

                var users = m.GetUsers(new Guid(Session["UserTicket"].ToString()));

                if (!String.IsNullOrEmpty(searchString))
                {
                    users = users.Where(s => s.name.Contains(searchString)
                                           || s.id.ToString().Contains(searchString)
                                           || s.surname.Contains(searchString)
                                           || s.Login.Contains(searchString));
                }

                switch (sortOrder)
                {
                    case "id_asc":
                        users = users.OrderByDescending(s => s.id);
                        break;
                    case "Name":
                        users = users.OrderBy(s => s.name);
                        break;
                    case "Name_desc":
                        users = users.OrderByDescending(s => s.name);
                        break;
                    case "Surname":
                        users = users.OrderBy(s => s.surname);
                        break;
                    case "Surname_desc":
                        users = users.OrderByDescending(s => s.surname);
                        break;
                    case "Login":
                        users = users.OrderBy(s => s.Login);
                        break;
                    case "Login_desc":
                        users = users.OrderByDescending(s => s.Login);
                        break;
                    case "IsAdmin":
                        users = users.OrderBy(s => s.isAdmin);
                        break;
                    case "IsAdmin_desc":
                        users = users.OrderByDescending(s => s.isAdmin);
                        break;
                    case "Unit":
                        users = users.OrderBy(s => s.isAdmin);
                        break;
                    case "Unit_desc":
                        users = users.OrderByDescending(s => s.unitName);
                        break;
                    default:  // id ascending 
                        users = users.OrderBy(s => s.id);
                        break;
                }

                int pageSize = 8;
                int pageNumber = (page ?? 1);
                return View(users.ToPagedList(pageNumber, pageSize));
            }

            RedirectToAction("Login", "login");
            return View();
        }

        public ActionResult UsersAdd()
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                var units = dataQueryService.GetUnits(new Guid(Session["UserTicket"].ToString()));

                var userAdd = new UserModels
                {
                    unitList = units.Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    })
                };

                return View(userAdd);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UsersAdd(UserModels model)
        {
            if (model.Password == model.repeatPassword)
            {
                if (model.Login != null && model.Password != null && model.surname != null)
                {
                    model.addUser(new Guid(Session["UserTicket"].ToString()), model);
              
                return Redirect("~/Users/Users");
                }
                return UsersAdd();
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult UsersEdit(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();     

                var user = dataQueryService.GetUser(id, new Guid(Session["UserTicket"].ToString()));     
                var units = dataQueryService.GetUnits(new Guid(Session["UserTicket"].ToString()));     
                    
                var model = new UserModels     
                {     
                     unitList = units.Select(u => new SelectListItem     
                    {     
                        Text = u.Name,     
                        Value = u.Id.ToString()     
                    })     
                };     

                model.id = user.Id;     
                model.name = user.Name;     
                model.surname = user.Surname;     
                model.Login = user.Login;     
                model.isAdmin = user.IsAdmin;     
                model.selectedUnitId = user.Unit.Id;     

                return View(model);     
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UsersEdit(UserModels model)
        {
            if (Session["UserTicket"] != null)
            {
                if (model.Login != null)
                {
                    model.editUser(model, new Guid(Session["UserTicket"].ToString()));
                    return Redirect("~/Users/Users");
                }
                return UsersEdit(model.id);
            }
            return Redirect("~/Login/Login");
        }
    }
}