using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;
using System.Web.Mvc;
using ProjektGlowny.DataQueryService;
using ProjektGlowny.DataCommandService;
using System.Web.Security;

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
        

        public void addUser(Guid ticket, UserModels model)
        {
            if (Login != null && model.Password != null && ticket != null)
            {
                IDataCommandService dataCommandService = new DataCommandServiceClient();
                AddUserRequest addUser = new AddUserRequest();

                addUser.Name = model.name;
                addUser.Surname = model.surname;
                addUser.Login = model.Login;
                addUser.IsAdmin = model.isAdmin;
                addUser.Password = model.Password;
                addUser.Ticket = ticket;
                addUser.UnitId = model.selectedUnitId;

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

        public void changePassword(UserModels model, Guid ticket)
        {
            ProjektGlowny.LoginService1.ILoginService loginService = new ProjektGlowny.LoginService1.LoginServiceClient();
            ProjektGlowny.LoginService1.ChangePasswordRequest changePassReq = new ProjektGlowny.LoginService1.ChangePasswordRequest();

            changePassReq.OldPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(model.oldPassword, "SHA1");
            changePassReq.NewPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1");
            changePassReq.TicketId = ticket;

            try
            {
                loginService.ChangePassword(changePassReq);
            }
            catch(Exception ex){ }
        }


        private DataCommandService.UnitInfo unitInfoConventer(DataQueryService.UnitInfo UnitInfo)
        {
            DataCommandService.UnitInfo dataCommUnitInfo = new DataCommandService.UnitInfo();

            dataCommUnitInfo.Id = UnitInfo.Id;
            dataCommUnitInfo.Name = UnitInfo.Name;
            dataCommUnitInfo.Description = UnitInfo.Description;
            dataCommUnitInfo.ExtensionData = UnitInfo.ExtensionData;

            return dataCommUnitInfo;
        }


        public void editUser(UserModels model, Guid ticket)
        {
            DataCommandService.IDataCommandService dataCommandService = new DataCommandService.DataCommandServiceClient();

            DataQueryService.IDataQueryService dataQueryService = new DataQueryService.DataQueryServiceClient();
            var unit = dataQueryService.GetUnit(model.selectedUnitId, ticket);


            if (model.Password != null)
            {
                if (model.Password == model.repeatPassword)
                {
                    DataCommandService.UserInfo user = new DataCommandService.UserInfo();

                    user.Id = model.id;
                    user.Name = model.name;
                    user.Surname = model.surname;
                    user.Login = model.Login;
                    user.IsAdmin = model.isAdmin;
                    user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, "SHA1");
                    user.Unit = unitInfoConventer(unit);

                    try
                    {
                        dataCommandService.AdminEditUsers(user, ticket);
                    }
                    catch (Exception ex)
                    { }
                }
            }
            else 
            {
                DataCommandService.UserEdit user = new DataCommandService.UserEdit();

                user.Id = model.id;
                user.Name = model.name;
                user.Surname = model.surname;
                user.IsAdmin = model.isAdmin;
                user.Unit = unitInfoConventer(unit);

                try
                {
                    dataCommandService.EditUsers(user, ticket);
                }
                catch (Exception ex)
                { }
            
            }

           

        }
    }
       
}