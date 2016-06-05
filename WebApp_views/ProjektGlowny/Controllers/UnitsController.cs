using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using ProjektGlowny.Models;

namespace ProjektGlowny.Controllers
{
    public class UnitsController : Controller
    {
        // GET: Units
        public ViewResult Units(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.NameSortParm = sortOrder == "Name" ? "Name_desc" : "Name";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                UnitsModel m = new UnitsModel();

                var units = m.getUnits(new Guid(Session["UserTicket"].ToString()));

                if (!String.IsNullOrEmpty(searchString))
                {
                    units = units.Where(s => s.Name.Contains(searchString)
                                           || s.Id.ToString().Contains(searchString)
                                           || s.Description.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "id_asc":
                        units = units.OrderByDescending(s => s.Id);
                        break;
                    case "Name":
                        units = units.OrderBy(s => s.Name);
                        break;
                    case "Name_desc":
                        units = units.OrderByDescending(s => s.Name);
                        break;
                    default:  // id ascending 
                        units = units.OrderBy(s => s.Id);
                        break;
                }

                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(units.ToPagedList(pageNumber, pageSize));
            }

            RedirectToAction("Login", "login");
            return View();
        }

        public ActionResult UnitsEdit(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();

                var unit = dataQueryService.GetUnit(id, new Guid(Session["UserTicket"].ToString()));

                UnitsModel model = new UnitsModel();

                model.Id = unit.Id;
                model.Name = unit.Name;
                model.Description = unit.Description;

                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UnitsEdit(UnitsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                if (model.Name != null)
                {   
                    model.editUnit(model, new Guid(Session["UserTicket"].ToString()));
                    return Redirect("~/Units/Units");
                }
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult UnitsAdd()
        {
            if (Session["UserTicket"] != null && Session["UserId"] != null)
            {
                UnitsModel model = new UnitsModel();
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult UnitsAdd(UnitsModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.addUnit(model, new Guid(Session["UserTicket"].ToString()));
                return Redirect("~/Units/Units");
            }
            return Redirect("~/Login/Login");
        }
    }
}