using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using ProjektGlowny.DataQueryService;

namespace ProjektGlowny.Models
{
    public class UserModels
    { 
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
       
        public string name { get; set; }
        public string surname { get; set; }
        public bool isAdmin { get; set; }
        public Unit unit { get; set; }

        public IEnumerable<UserModels> GetUsers(Guid ticket)
        {
            List<UserModels> users = new List<UserModels>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetUsers(ticket);

            foreach (UserInfo user in result)
            {
                users.Add(new UserModels()
                {
                    name = user.Name,
                    surname = user.Surname,
                    isAdmin = user.IsAdmin,
                    unit = user.Unit,
                    Login = user.Login,

                });
            }

            return users;
        }
    }
       
}