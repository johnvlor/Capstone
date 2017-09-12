using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Event
    {
        [Key]
        public int ID { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool AllDay { get; set; }

        [Display (Name="Calendar Color")]
        public string ThemeColor { get; set; }

        [Display (Name = "Add to Announcements?")]
        public bool Announcement { get; set; }

        [Display(Name = "Add to Events Page?")]
        public bool EventsPage { get; set; }

        [Display (Name = "Contact")]
        public string ContactName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string ContactEmail { get; set; }

        [Display(Name = "Phone")]
        [RegularExpression(@"\d{10}$", ErrorMessage = "Invalid Phone Number")]
        public string ContactPhone { get; set; }

        public string Location { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [RegularExpression(@"\d{5}$", ErrorMessage = "Invalid Zip Code")]
        public string Zip { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [Display(Name = "Sign up Needed?")]
        public bool Register { get; set; }
    }
}