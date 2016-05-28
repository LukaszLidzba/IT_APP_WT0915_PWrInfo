using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;
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

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Stare hasło")]
        public string oldPassword { get; set; }
        
        [Display(Name = "Imię")]
        public string name { get; set; }

        [Display(Name = "Nazwisko")]
        public string surname { get; set; }

        [Display(Name = "Administrator")]
        public bool isAdmin { get; set; }

        [Display(Name = "Jednostka")]
        public string unitName { get; set; }

        [Display(Name = "Jednostka")]
        public IEnumerable<SelectListItem> unitList { get; set; }
        public int selectedUnitId { get; set; }

        [Display(Name = "Jednostka")]
        public DataCommandService.UnitInfo unit { get; set; }

        [Display(Name = "Id")]
        public int id { get; set; }
        

        public void addUser(Guid ticket, string name, string surname, string password, string login, int unitId, bool isAdmin)
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

                try
                {
                    dataCommandService.AddUser(addUser);
                }
                catch (Exception ex) { }
            }

        }

        public IEnumerable<UserModels> GetUsers(Guid ticket)
        {
            List<UserModels> users = new List<UserModels>();

            IDataQueryService dataQueryService = new DataQueryServiceClient();

            var result = dataQueryService.GetUsers(ticket);

            foreach (DataQueryService.UserInfo user in result)
            {
                users.Add(new UserModels()
                {
                    id = user.Id,
                    name = user.Name,
                    surname = user.Surname,
                    isAdmin = user.IsAdmin,
                    unitName = user.Unit.Name,
                    Login = user.Login,

                });
            }
           return users;
        }

        public UserModels GetUser(Guid ticket)
        {

            ProjektGlowny.LoginService1.ILoginService loginService = new ProjektGlowny.LoginService1.LoginServiceClient();
            ProjektGlowny.LoginService1.UserInfo result = new ProjektGlowny.LoginService1.UserInfo();

            result = loginService.GetUser(ticket);

            UserModels user = new UserModels();

            user.name = result.Name;
            user.surname = result.Surname;
            user.isAdmin =  result.IsAdmin; 
            user.unitName = result.Unit.Name;
            user.Login = result.Login;

            return user;
                    
        }

        private DataCommandService.UnitInfo unitInfoConventer( LoginService1.UnitInfo logUnitInfo)
        {
            DataCommandService.UnitInfo dataCommUnitInfo = new DataCommandService.UnitInfo();

            dataCommUnitInfo.Id = logUnitInfo.Id;
            dataCommUnitInfo.Name = logUnitInfo.Name;
            dataCommUnitInfo.Description = logUnitInfo.Description;
            dataCommUnitInfo.ExtensionData = logUnitInfo.ExtensionData;

            return dataCommUnitInfo;
        }

        public void changePassword(UserModels model, Guid ticket)
        {
            DataCommandService.UserInfo user = new DataCommandService.UserInfo();

            ProjektGlowny.LoginService1.ILoginService loginService = new ProjektGlowny.LoginService1.LoginServiceClient();
            ProjektGlowny.LoginService1.UserInfo result = new ProjektGlowny.LoginService1.UserInfo();

            IDataCommandService dataCommandService = new DataCommandServiceClient();
            
            result = loginService.GetUser(ticket);

            user.Id = result.Id;
            user.IsAdmin = result.IsAdmin;
            user.Login = result.Login;
            user.Surname = result.Surname;
            user.Password = model.Password;
            user.Unit = unitInfoConventer(result.Unit);
            user.Name = result.Name;

            try
            {
                dataCommandService.EditUsers(user, ticket);
            }
            catch(Exception ex){ }
        }
    }
       
}