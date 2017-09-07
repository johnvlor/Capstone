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
        public ActionResult Index()
        {
            var donations = db.PayPalModel.ToList();
            return View(donations);
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
                Date = ViewBag.result.PaymentDate,
                PaymentAmount = ViewBag.result.GrossTotal               
            };

            db.PayPalModel.Add(newPayPal);
            db.SaveChanges();

            return View("Success");
        }

    }
}