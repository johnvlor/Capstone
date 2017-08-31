using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class Announcement
    {
        [Key]
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }
    }
}