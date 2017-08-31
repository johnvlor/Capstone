using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class User
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

        //[ForeignKey("ApplicationUser")]
        public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}