using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjektGlowny.DataQueryService;

namespace ProjektGlowny.Models
{
    public class UnitsModel
    {
        [Display(Name = "Id")]
        public int Id { set; get; }

        [Display(Name = "Nazwa")]
        public string Name { set; get; }

        [Display(Name = "Opis")]
        public string Description { set; get; }


        public IEnumerable<UnitsModel> getUnits(Guid ticket)
        {
            List<UnitsModel> m = new List<UnitsModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetUnits(ticket);

            foreach (UnitInfo unit in result)
            {
                m.Add(new UnitsModel()
                {
                    Id = unit.Id,
                    Name = unit.Name,
                    Description = unit.Description,
                });
            }
            return m;

        }

        public void addUnit()
        { }

        public void editUnit()
        { }

        public void deleteUnit()
        { }

    }
}