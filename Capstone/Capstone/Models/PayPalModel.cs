using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Capstone.Models
{
    public class PayPalModel
    {
        [Key]
        public int ID { get; set; }

        public double PaymentAmount { get; set; }

        public string Date { get; set; }

    }
}