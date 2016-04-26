using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGlowny.DataQueryService;
namespace ProjektGlowny.Models
{
    public class EventsModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Department departments { get; set; }
        public string content { get; set; }
        public string title { get; set; }
        public DateTime extensionDate { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime Date { get; set; } 
        public string filtred { get; set; }

        public IEnumerable<EventsModel> GetEvents(Guid ticket)
        {
            List<EventsModel> e = new List<EventsModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetEvents(ticket);

            foreach (EventInfo events in result)
            {
                e.Add(new EventsModel()
                {
                    Id = events.Id,
                    content = events.Content,
                    UserId = events.UserId,
                    departments = events.Department,
                    title = events.Title,
                    //extensionDate = DateTime.Parse(events.ExtensionData.ToString()),
                   // Date = DateTime.Parse(events.Date.ToString()),
                   // NotificationDate = DateTime.Parse(events.NotificationDate.ToString()),
                });
            }

            return e;
        }
    }
}