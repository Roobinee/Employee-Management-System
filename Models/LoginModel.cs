using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MyProject1.Models
{
    public class LoginModel
    {
        //Validation of username
        [Required(ErrorMessage = "UserName is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        // Validation of password
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}