using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektGlowny.Models;

namespace ProjektGlowny.Controllers
{
    public class MessagesController : Controller
    {
        // GET: Messages
        public ActionResult Messages()
        {
            if (Session["UserTicket"] != null)
            {
            return View();
            }
            return Redirect("~/Login/Login");
        }

        public ActionResult MessagesEdit()
        {
            if (Session["UserTicket"] != null)
            {
            return View();
                }
            return Redirect("~/Login/Login");
        }

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