using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjektGlowny.DataQueryService;

namespace ProjektGlowny.Models
{
    public class DeansOfficesModel
    {
        [Display(Name = "Id")]
        public int Id { set; get; }

        [Display(Name = "Nazwa")]
        public string AdditionalInfo { set; get; }

        [Display(Name = "Adres")]
        public string Address { set; get; }

        [Display(Name = "Wydział")]
        public Department Department { set; get; }

        [Display(Name = "Godziny otwarcia")]
        public string OpeningHours { set; get; }

        [Display(Name = "Id użytkownika")]
        public int UserId { set; get; }

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
    }
}