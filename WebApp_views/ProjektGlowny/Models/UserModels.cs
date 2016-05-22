using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using ProjektGlowny.DataQueryService;
using ProjektGlowny.DataCommandService;

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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Powtórz hasło")]
        public string repeatPassword { get; set; }
        
        [Display(Name = "Imię")]
        public string name { get; set; }

        [Display(Name = "Nazwisko")]
        public string surname { get; set; }

        [Display(Name = "Administrator")]
        public bool isAdmin { get; set; }

        [Display(Name = "Jednostka")]
        public Unit unit { get; set; }


        public void addUser(Guid ticket, string name, string surname, string password, string login, int unitId,  bool isAdmin)
        {
            if (Login != null && password != null && ticket != null)
            {
                IDataCommandService dataCommandService = new DataCommandServiceClient();
                AddUserRequest addUser = new AddUserRequest();

                addUser.Name = name;
                addUser.Surname = surname;
                addUser.Login = login;
                addUser.IsAdmin = isAdmin;
                addUser.Password = password;
                addUser.Ticket = ticket;
                addUser.UnitId = unitId;
   
                dataCommandService.AddUser(addUser);
            }

        }

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
            //TODO nie ładuje poprawnie unit
            return users;
        }

        public UserModels GetUser(Guid ticket)
        {

            ProjektGlowny.LoginService1.ILoginService loginService = new ProjektGlowny.LoginService1.LoginServiceClient();

            var result = loginService.GetUser(ticket);

            UserModels user = new UserModels();

            user.name = result.Name;
            user.surname = result.Surname;
            user.isAdmin =  result.IsAdmin; 
          //  user.unit.Id =  result.Unit.Id;
          //  user.unit.Name = result.Unit.Name;
          //  user.unit.Description = result.Unit.Description;
            user.Login = result.Login;

            return user;
                    
        }
    }
       
}