using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MyProject1.Models
{
    public class UpdateEmployeeModel
    {
        public static int EmployeeID { get; set; }

        [Required(ErrorMessage = "*FirstName is required")]
        [RegularExpression("^[A-Z]*[a-z]+$")]
        [Display(Name = "FirstName")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "*LastName is required")]
        [RegularExpression("^[A-Z]*[a-z]+$")]
        [Display(Name = "LastName")]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "TitleOfCourtesy")]
        public string TitleOfCourtesy { get; set; }

        [Display(Name = "BirthDate")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Address")]
        [MaxLength(25)]
        public string Address { get; set; }

        [Display(Name = "City")]
        [MaxLength(15)]
        public string City { get; set; }

        [Display(Name = "Country")]
        [MaxLength(15)]
        public string Country { get; set; }

        [RegularExpression("^[0-9]+$")]
        [StringLength(10)]
        [Display(Name = "HomePhone")]
        public string HomePhone { get; set; }
    }
}