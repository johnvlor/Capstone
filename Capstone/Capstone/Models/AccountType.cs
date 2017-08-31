using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class AccountType
    {
        [Key]
        public int ID { get; set; }

        public string Type { get; set; }
    }
}