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

        [Display(Name = "data1")]
        public DateTime extensionDate { get; set; }

        [Display(Name = "data2")]
        public DateTime notificationDate { get; set; }

        [Display(Name = "data3")]
        public DateTime date { get; set; } 

        //public string filtred { get; set; }

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
                    // extensionDate = DateTime.Parse(events.ExtensionData),// to nie jest string tylko data
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
                   // extensionDate = DateTime.Parse(events.ExtensionData),// to nie jest string tylko data
                    date = DateTime.Parse(events.Date),
                    notificationDate = DateTime.Parse(events.NotificationDate),
                    
                });
            }

            return e;
        }
    }
}