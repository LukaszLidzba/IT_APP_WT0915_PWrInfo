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

        public ActionResult DeansOfficesAdd()
        {
            if (Session["UserTicket"] != null && Session["UserId"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString()));

                var model = new DeansOfficesModel
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
        public ActionResult DeansOfficesAdd(DeansOfficesModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.addDeanOffice(model, new Guid(Session["UserTicket"].ToString()));
                return Redirect("~/DeansOffices/DeansOffices");
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult DeansOfficesEdit(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
               
                var DeansOff = dataQueryService.GetDeansOfficeInfo(id, new Guid(Session["UserTicket"].ToString()));
                var departments = dataQueryService.GetAllDeansOffices(new Guid(Session["UserTicket"].ToString()));

                var model = new DeansOfficesModel
                {
                    departmentsList = departments.Select(d => new SelectListItem
                    {
                        Text = d.Department.Name,
                        Value = d.Id.ToString()
                    })
                };

                if (DeansOff != null)
                {
                    model.Id = DeansOff.Id;
                    model.AdditionalInfo = DeansOff.AdditionalInfo;
                    model.Address = DeansOff.Address;
                    model.Department = DeansOff.Department;
                    model.OpeningHours = DeansOff.OpeningHours;
                    model.UserId = DeansOff.UserId;
                    model.selectedDepartmentId = DeansOff.Department.Id;

                    return View(model);
                }
                return Redirect("~/DeansOffices/DeansOffices");
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult DeansOfficesEdit(DeansOfficesModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.editDeanOffice(model, new Guid(Session["UserTicket"].ToString()));
                return Redirect("~/DeansOffices/DeansOffices");
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult DeansOfficesDelete(int id)
        {
            if (Session["UserTicket"] != null)
            {
                DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
                DeansOfficesModel model = new DeansOfficesModel();

                var DeansOff = dataQueryService.GetDeansOfficeInfo(id, new Guid(Session["UserTicket"].ToString()));

                if (DeansOff != null)
                {
                    model.Id = DeansOff.Id;
                    model.AdditionalInfo = DeansOff.AdditionalInfo;
                    model.Address = DeansOff.Address;
                    model.Department = DeansOff.Department;
                    model.OpeningHours = DeansOff.OpeningHours;
                    model.UserId = DeansOff.UserId;

                    return View(model);
                }
                return View(model);
            }
            return Redirect("~/Login/Login");
        }

        [HttpPost]
        public ActionResult DeansOfficesDelete(DeansOfficesModel model)
        {
            if (Session["UserTicket"] != null)
            {
                model.deleteDeanOffice(model, new Guid(Session["UserTicket"].ToString()));
                return Redirect("~/DeansOffices/DeansOffices");
            }
            return Redirect("~/Login/Login");
        }

    }
}