using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Security;

namespace ProjektGlowny.Models
{
    public class UserModels
    { 
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Hasło")]
        public string Password { get; set; }

        [Display(Name = "Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
       
}