using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Member
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Name
        {
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        //public string Address { get; set; }

        //public string City { get; set; }

        //public string State { get; set; }

        //[RegularExpression(@"\d{5}$", ErrorMessage = "Invalid Zip Code")]
        //public string Zip { get; set; }

        public string Additional { get; set; }

        public int EventID { get; set; }
        public virtual Event Event { get; set; }
    }
}