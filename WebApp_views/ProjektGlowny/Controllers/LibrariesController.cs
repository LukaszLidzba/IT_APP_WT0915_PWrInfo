﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;
using PagedList;

namespace ProjektGlowny.Controllers
{
    public class LibrariesController : Controller
    {
        // GET: Libraries

        public ViewResult Libraries(string sortOrder, string currentFilter, string searchString, int? page)
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

                LibrariesModel m = new LibrariesModel();

                var libraries = m.getLibraries(new Guid(Session["UserTicket"].ToString()));

                if (!String.IsNullOrEmpty(searchString))
                {
                    libraries = libraries.Where(s => s.Name.Contains(searchString)
                                           || s.Id.ToString().Contains(searchString)
                                           || s.AdditionalInfo.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "id_asc":
                        libraries = libraries.OrderByDescending(s => s.Id);
                        break;
                    case "Name":
                        libraries = libraries.OrderBy(s => s.Name);
                        break;
                    case "Name_desc":
                        libraries = libraries.OrderByDescending(s => s.Name);
                        break;
                    default:  // id ascending 
                        libraries = libraries.OrderBy(s => s.Id);
                        break;
                }

                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(libraries.ToPagedList(pageNumber, pageSize));
            }

            RedirectToAction("Login", "login");
            return View();
        }

        public ActionResult LibrariesEdit()
        {
            return View();
        }
    }
}