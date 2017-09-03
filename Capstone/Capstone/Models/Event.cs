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

        //public string EventID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool AllDay { get; set; }

        public string ThemeColor { get; set; }

        public bool Announcement { get; set; }
    }
}