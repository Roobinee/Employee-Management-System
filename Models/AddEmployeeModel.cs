using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MyProject1.Models
{
    public class AddEmployeeModel
    {
        public static List<string> TitleList = new List<string>();
        public static List<string> TitleOfCourtesyList = new List<string> { "", "Dr.", "Mr.", "Mrs.", "Ms." };
        [Required]
        [Display(Name = "Firstname : ")]
        [MaxLength(10)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Lastname : ")]
        [MaxLength(20)]
        public string LastName { get; set; }


        [Display(Name = "Title : ")]
        public string Title { get; set; }

        [Display(Name = "TitleOfCourtesy : ")]
        public string TitleOfCourtesy { get; set; }

        [Display(Name = "BirthDate : ")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Address : ")]
        [MaxLength(60)]
        public string Address { get; set; }

        [Display(Name = "City : ")]
        [MaxLength(15)]
        public string City { get; set; }

        [Display(Name = "Country : ")]
        [MaxLength(15)]
        public string Country { get; set; }

        [Display(Name = "HomePhone : ")]
        [StringLength(10)]
        public string HomePhone { get; set; }
    }
}