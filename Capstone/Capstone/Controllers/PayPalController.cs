using Capstone.Models;
using Capstone.PayPal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Controllers
{
    public class PayPalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PayPal
        //[HttpGet]
        public ActionResult Index()
        {
            double totalDonations = 0;

            var donations = db.PayPalModel.ToList();
            foreach (var d in donations)
            {
                totalDonations = totalDonations + d.PaymentAmount;
            }

            ViewBag.TotalDonations = totalDonations;

            return View(donations);
        }

        [HttpPost]
        public ActionResult Index(DateTime startDate, DateTime endDate)
        {
            double totalDonations = 0;
            List<PayPalModel> newDonation = new List<PayPalModel>();

            var donations = db.PayPalModel.ToList();
            foreach (var d in donations)
            {
                if (d.Date.Date >= startDate.Date && d.Date.Date <= endDate.Date)
                {
                    totalDonations = totalDonations + d.PaymentAmount;
                    newDonation.Add(d);
                }
            }

            ViewBag.TotalDonations = totalDonations;

            return View(newDonation);
        }

        public ActionResult PayPal()
        {
            return View();
        }

        public ActionResult Success()
        {
            ViewBag.result = PDTHolder.Success(Request.QueryString.Get("tx"));

            PayPalModel newPayPal = new PayPalModel()
            {
                Date = DateTime.Now,
                PaymentAmount = ViewBag.result.GrossTotal,
                PayPalTransactionID = ViewBag.result.TransactionId
            };

            //newPayPal.Date = String.Format("HH:mm:ss MMM dd, yyyy {0}", newPayPal.Date.Substring(newPayPal.Date.Length - 3));

            db.PayPalModel.Add(newPayPal);
            db.SaveChanges();

            return View("Success");
        }

    }
}