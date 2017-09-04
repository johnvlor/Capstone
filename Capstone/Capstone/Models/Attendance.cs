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

        public DateTime Date { get; set; }
    }
}