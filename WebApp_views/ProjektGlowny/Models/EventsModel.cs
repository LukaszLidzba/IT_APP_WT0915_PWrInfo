using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGlowny.DataQueryService;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "treśc")]
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

            var result = dataQueryService.GetEvents(ticket, DateTime.Now.AddDays(-60), DateTime.Now);

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
        {}

        public void editEvent(EventsModel model, Guid ticket) 
        { }

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