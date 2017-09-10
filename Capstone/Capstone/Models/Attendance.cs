using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Attendance
    {
        [Key]
        public int ID { get; set; }

        public int Service { get; set; }

        public int SundaySchool { get; set; }

        public int Guest { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        [Display (Name ="Total Attendance")]
        public double Total { get; set; }
    }
}