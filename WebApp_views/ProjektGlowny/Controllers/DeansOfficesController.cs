using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using PagedList;

namespace ProjektGlowny.Controllers
{
    public class DeansOfficesController : Controller
    {
        // GET: DeansOffices
       public ViewResult DeansOffices(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (Session["UserTicket"] != null)
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_asc" : "";
                ViewBag.NameSortParm = sortOrder == "AdditionalInfo" ? "AdditionalInfo_desc" : "AdditionalInfo";
                ViewBag.DeanOfficeSortParm = sortOrder == "DeanOffice" ? "DeanOffice_desc" : "DeanOffice";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                DeansOfficesModel m = new DeansOfficesModel();

                var deansOffices = m.GetDeansOffices(new Guid(Session["UserTicket"].ToString()));

                if (!String.IsNullOrEmpty(searchString))
                {
                    deansOffices = deansOffices.Where(s => s.AdditionalInfo.Contains(searchString)
                                           || s.Id.ToString().Contains(searchString)
                                           || s.Department.Name.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "id_asc":
                        deansOffices = deansOffices.OrderByDescending(s => s.Id);
                        break;
                    case "AdditionalInfo":
                        deansOffices = deansOffices.OrderBy(s => s.AdditionalInfo);
                        break;
                    case "AdditionalInfo_desc":
                        deansOffices = deansOffices.OrderByDescending(s => s.AdditionalInfo);
                        break;
                    case "DeanOffice":
                        deansOffices = deansOffices.OrderBy(s => s.Department.Name);
                        break;
                    case "DeanOffice_desc":
                        deansOffices = deansOffices.OrderByDescending(s => s.Department.Name);
                        break;
                    default:  // id ascending 
                        deansOffices = deansOffices.OrderBy(s => s.Id);
                        break;
                }

                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(deansOffices.ToPagedList(pageNumber, pageSize));
            }

            RedirectToAction("Login", "login");
            return View();
        }

        public ActionResult DeansOfficesEdit()
        {
            return View();
        }
    }
}