﻿using System;
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

        [Display (Name ="Donation Amount")]
        public double PaymentAmount { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime Date { get; set; }

        public string PayPalTransactionID { get; set; }

    }
}