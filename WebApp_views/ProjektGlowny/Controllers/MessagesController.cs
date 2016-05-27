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
                MessagesModel m = new MessagesModel();
                IList<MessagesModel> messages = m.GetMessages(new Guid(Session["UserTicket"].ToString())).ToList();

                return View(messages);

            }
            return Redirect("~/Login/Login");
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