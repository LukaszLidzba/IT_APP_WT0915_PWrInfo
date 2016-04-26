using ProjektGlowny.DataQueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 

namespace ProjektGlowny.Models
{
    public class MessagesModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Departments departments { get; set; }
        public string content { get; set; }
        public string title { get; set; }
        public bool important { get; set; }
        public string filtred { get; set; }

        public IEnumerable<MessagesModel> GetMessages(Guid ticket)
        {
            List<MessagesModel> m = new List<MessagesModel>();
               
            IDataQueryService  dataQueryService = new DataQueryServiceClient();
               
            var result = dataQueryService.GetMessages(ticket);

            foreach (MessageInfo msg in result)
            {
                m.Add(new MessagesModel()    
                {    
                    Id = msg.Id,    
                    content = msg.Content,    
                    UserId = msg.UserId,    
                    departments = msg.Department,    
                    title = msg.Title,    
                    important = msg.Important    
                });    
            } 
           
            return m;
        }
    }
}