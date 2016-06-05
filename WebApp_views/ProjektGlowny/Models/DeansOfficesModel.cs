using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjektGlowny.DataQueryService;
using System.Web.Mvc;

namespace ProjektGlowny.Models
{
    public class DeansOfficesModel
    {
        [Display(Name = "Id")]
        public int Id { set; get; }

        [Display(Name = "Dodatakowe informacje")]
        public string AdditionalInfo { set; get; }

        [Display(Name = "Adres")]
        public string Address { set; get; }

        [Display(Name = "Wydział")]
        public Department Department { set; get; }

        [Display(Name = "Godziny otwarcia")]
        public string OpeningHours { set; get; }

        [Display(Name = "Id użytkownika")]
        public int UserId { set; get; }

        [Display(Name = "Wydział")]
        public IEnumerable<SelectListItem> departmentsList { get; set; }
        public int selectedDepartmentId { get; set; }

        public IEnumerable<DeansOfficesModel> GetDeansOffices(Guid ticket)
        {
            List<DeansOfficesModel> m = new List<DeansOfficesModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetAllDeansOffices(ticket);

            foreach (DeansOfficeInfo DeansOff in result)
            {
                m.Add(new DeansOfficesModel()
                {
                    Id = DeansOff.Id,
                    AdditionalInfo = DeansOff.AdditionalInfo,
                    Address = DeansOff.Address,
                    Department = DeansOff.Department,
                    OpeningHours = DeansOff.OpeningHours,
                    UserId = DeansOff.UserId
                });
            }

            return m;
        }

        public void addDeanOffice(DeansOfficesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataCommandService.AddDeansOfficeRequest deansOffice = new DataCommandService.AddDeansOfficeRequest();

            deansOffice.DepartmentId = model.selectedDepartmentId;
            deansOffice.AdditionalInfo = model.AdditionalInfo;
            deansOffice.Address = model.Address;
            deansOffice.OpeningHours = model.OpeningHours;
            deansOffice.Ticket = ticket;
        
            try
            {
                dataCommandService.AddDeansOffice(deansOffice);
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

        public void editDeanOffice(DeansOfficesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();
            DataCommandService.DeansOfficeInfo deansOffice = new DataCommandService.DeansOfficeInfo();

            DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
            var department = dataQueryService.GetDepartment(model.selectedDepartmentId, ticket);

            deansOffice.Id = model.Id;
            deansOffice.AdditionalInfo = model.AdditionalInfo;
            deansOffice.Address = model.Address;
            deansOffice.OpeningHours = model.OpeningHours;
            deansOffice.UserId = model.UserId;
            deansOffice.Department = departInfoConventer(department);

            try
            {
                dataCommandService.EditDeansOffices(deansOffice, ticket);
            }
            catch (Exception ex)
            { }
        }

        public void deleteDeanOffice(DeansOfficesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataCommandService.DeleteRequest deansOffice = new DataCommandService.DeleteRequest();

            deansOffice.Id = model.Id;
            deansOffice.Ticket = ticket;

            try
            {
                dataCommandService.DeleteDeansOffices(deansOffice);
            }
            catch (Exception ex)
            { }
        }
    }
}