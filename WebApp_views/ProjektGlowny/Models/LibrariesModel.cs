using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ProjektGlowny.DataQueryService;

namespace ProjektGlowny.Models
{
    public class LibrariesModel
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Informacje dodatkowe")]
        public string AdditionalInfo { set; get; }

        [Display(Name = "Adres")]
        public string Address { set; get; }

        [Display(Name = "Godziny otwarcia")]
        public string OpeningHours { set; get; }

        [Display(Name = "Nazwa")]
        public string Name { set; get; }

        [Display(Name = "Id użytkownika")]
        public int UserId { set; get; }


        public IEnumerable<LibrariesModel> getLibraries(Guid ticket)
        {
            List<LibrariesModel> m = new List<LibrariesModel>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetLibraries(ticket);

            foreach (LibraryInfo lib in result)
            {
                m.Add(new LibrariesModel()
                {
                    Id = lib.Id,
                    Name = lib.Name,
                    Address = lib.Address,
                    AdditionalInfo = lib.AdditionalInfo,
                    OpeningHours = lib.OpeningHours,
                    UserId = lib.UserId

                });
            }
            return m;

         }

        public void addLibrary(LibrariesModel model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataCommandService.AddLibraryRequest library = new DataCommandService.AddLibraryRequest();

            library.Name = model.Name;
            library.OpeningHours = model.OpeningHours;
            library.AdditionalInfo = model.AdditionalInfo;
            library.Address = model.Address;
            library.Ticket = ticket;

            try
            {
                dataCommandService.AddLibrary(library);
            }
            catch (Exception ex)
            { }

        }

        public void editLibrary()
        {}

        public void deleteLibrary()
        {}
    }
}