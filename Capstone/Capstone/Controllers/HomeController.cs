using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Capstone.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var announcements = db.Announcement.ToList().OrderByDescending(a => a.Created).Take(10);

            return View(announcements);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PrayerRequest()
        {
            ViewBag.Message = "Submit your Prayer Request.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PrayerRequest(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("lortableforsix@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("teamintegrationproject@gmail.com");  // replace with valid value
                message.Subject = "Prayer Request";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "teamintegrationproject@gmail.com",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(model);
        }

        public ActionResult Sent()
        {
            return View();
        }

        public async Task<ActionResult> EventRegistration(Member member)
        {
            var events = db.Event.Single(e => e.ID == member.EventID);

            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p>" +
                    "<p>Message:</p>" +
                    "<p>Yes, I will be attending the below.</p>" +
                    "<p>{2}</p>" +
                    "<p>When: {3}</p>" +
                    "<p>Where: {9}" +
                    "<p>{4}, {5}, {6} {7}</p>" +
                    "<p>Thanks,</p>" +
                    "<p>{8}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress(events.ContactEmail));  // replace with valid value 
                message.From = new MailAddress("teamintegrationproject@gmail.com");  // replace with valid value
                message.Subject = events.Name + " - Event Registration";
                message.Body = string.Format(body, member.Name, member.Email, events.Name, events.Start, events.Address, events.City, events.State, events.Zip, member.Name, events.Location);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "teamintegrationproject@gmail.com",  // replace with valid value
                        Password = ""  // replace with valid value
                    };
                    smtp.Credentials = credential;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Sent");
                }
            }
            return View(member);
        }
    }
}