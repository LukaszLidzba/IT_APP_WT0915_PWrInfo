using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGlowny.DataQueryService;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
 
namespace ProjektGlowny.Models
{
    public class EventsModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Id użytkownika")]
        public int UserId { get; set; }

        [Display(Name = "Wydział")]
        public Department departments { get; set; }

        [Display(Name = "Wydział")]
        public IEnumerable<SelectListItem> departmentsList { get; set; }
        public int selectedDepartmentId { get; set; }

        [Display(Name = "Treść")]
        public string content { get; set; }

        [Display(Name = "Tytuł")]
        public string title { get; set; }
       
        [Display(Name = "Data przypomnienia")]
        public DateTime notificationDate { get; set; }

        [Display(Name = "Data wydarzenia")]
        public DateTime date { get; set; } 


        public IEnumerable<EventsModel> GetEvents(Guid ticket, DateTime startDate, DateTime endDate)
        {
            List<EventsModel> e = new List<EventsModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetEvents(ticket, startDate, endDate);
                CultureInfo provider = CultureInfo.InvariantCulture;

            foreach (EventInfo events in result)
            {
                e.Add(new EventsModel()
                {
                    Id = events.Id,
                    content = events.Content,
                    UserId = events.UserId,
                    departments = events.Department,
                    title = events.Title,
                    date = DateTime.Parse(events.Date),
                    notificationDate = DateTime.Parse(events.NotificationDate),
                   
                });
            }

            return e;
        }

        public IEnumerable<EventsModel> GetEvents(Guid ticket)
        {
            List<EventsModel> e = new List<EventsModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetEvents(ticket,null,null);
            
            foreach (EventInfo events in result)
            {
                e.Add(new EventsModel()
                {   
                    Id = events.Id,
                    content = events.Content,
                    UserId = events.UserId,
                    departments = events.Department,
                    title = events.Title,
                    date = DateTime.Parse(events.Date),
                    notificationDate = DateTime.Parse(events.NotificationDate),
                    
                });
            }

            return e;
        }

        public void addEvent(EventsModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();
            DataCommandService.AddEventRequest evnt = new DataCommandService.AddEventRequest();

            evnt.Title = model.title;
            evnt.Content = model.content;
            evnt.Ticket = ticket;
            evnt.DepartmentId = model.selectedDepartmentId;
            evnt.Date = model.date;
            evnt.NotificationDate = model.notificationDate;

            try
            {
                dataCommandService.AddEvent(evnt);
            }
            catch (Exception ex)
            { }
        
        }

        private DataCommandService.Department departInfoConventer(DataQueryService.Department queryDepartInfo)
        {
            DataCommandService.Department dataCommDepartInfo = new DataCommandService.Department();

            dataCommDepartInfo.Id = queryDepartInfo.Id;
            dataCommDepartInfo.Name = queryDepartInfo.Name;
            dataCommDepartInfo.ExtensionData = queryDepartInfo.ExtensionData;

            return dataCommDepartInfo;
        }

        public void editEvent(EventsModel model, Guid ticket) 
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();
            DataCommandService.EventInfo evnt = new DataCommandService.EventInfo();

            DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
            var department = dataQueryService.GetDepartment(model.selectedDepartmentId, ticket);

            evnt.Title = model.title;
            evnt.Content = model.content;
            evnt.Date = model.date.ToString();
            evnt.NotificationDate = model.notificationDate.ToString();
            evnt.UserId = model.UserId;
            evnt.Id = model.Id;
            evnt.Department = departInfoConventer(department);

            try
            {
                dataCommandService.EditEvents(evnt, ticket);
            }
            catch (Exception ex)
            { }
        }

        public void deleteEvent(EventsModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();
            DataCommandService.DeleteRequest evnt = new DataCommandService.DeleteRequest();

            evnt.Id = model.Id;
            evnt.Ticket = ticket;

            try
            {
                dataCommandService.DeleteEvents(evnt);
            }
            catch (Exception ex)
            { }

        }
    }
}