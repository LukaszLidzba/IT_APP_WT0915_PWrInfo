using ProjektGlowny.DataQueryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
 
namespace ProjektGlowny.Models
{
    public class MessagesModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Id użytkownika")]
        public int UserId { get; set; }

        [Display(Name = "Wydział")]
        public Departments departments { get; set; }

        [Display(Name = "Wydział")]
        public IEnumerable<SelectListItem> departmentsList { get; set; }
        public int selectedDepartmentId { get; set; }

        [Display(Name = "Treść")]
        public string content { get; set; }

        [Display(Name = "Tytuł")]
        public string title { get; set; }

        [Display(Name = "Czy ważne?")]
        public bool important { get; set; }
      

        public IEnumerable<MessagesModel> GetMessages(Guid ticket)
        {
            List<MessagesModel> m = new List<MessagesModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetMessages(ticket, null);

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

        public IEnumerable<MessagesModel> GetMessages(Guid ticket, DateTime startDate)
        {
            List<MessagesModel> m = new List<MessagesModel>();
               
            IDataQueryService  dataQueryService = new DataQueryServiceClient();
               
            var result = dataQueryService.GetMessages(ticket, startDate);

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
               
        public void addMessage(MessagesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataCommandService.AddMessageRequest message = new DataCommandService.AddMessageRequest();

            message.Title = model.title;
            message.Content = model.content;
            message.Ticket = ticket;
            message.Important = model.important;
            message.DepartmentId = model.selectedDepartmentId;
          
            try
            {
                dataCommandService.AddMessage(message);
            }
            catch (Exception ex)
            { }

        }

        private DataCommandService.Departments departInfoConventer(DataQueryService.Department queryDepartInfo)
        {
            DataCommandService.Departments dataCommDepartInfo = new DataCommandService.Departments();

            dataCommDepartInfo.Id = queryDepartInfo.Id;
            dataCommDepartInfo.Name = queryDepartInfo.Name;
            dataCommDepartInfo.ExtensionData = queryDepartInfo.ExtensionData;

            return dataCommDepartInfo;
        }

        public void editMessage(MessagesModel model, Guid ticket) 
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();
            DataCommandService.MessageInfo message = new DataCommandService.MessageInfo();

            DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
            var department = dataQueryService.GetDepartment(model.selectedDepartmentId, ticket);

            message.Id = model.Id;
            message.Title = model.title;
            message.Content = model.content;
            message.Important = model.important;
            message.UserId = model.UserId;
            message.Department = departInfoConventer(department);

            try
            {
                dataCommandService.EditMessages(message,ticket);
            }
            catch (Exception ex)
            { }

        }

        public void deleteMessage(MessagesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataCommandService.DeleteRequest message = new DataCommandService.DeleteRequest();

            message.Id = model.Id;
            message.Ticket = ticket;

            try
            {
                dataCommandService.DeleteMessages(message);
            }
            catch (Exception ex)
            { }

        }

    }
}