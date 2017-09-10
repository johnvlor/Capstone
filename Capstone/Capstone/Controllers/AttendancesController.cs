using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstone.Models;

namespace Capstone.Controllers
{
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public ActionResult Index()
        {
            var today = DateTime.Today;
            var attendances = db.Attendance.Where(a => a.Date == today);

            return View(attendances);
        }

        public ActionResult IndexReport()
        {
            var attendances = db.Attendance;

            return View(attendances);
        }

        [HttpPost]
        public ActionResult IndexReport(DateTime startDate, DateTime endDate)
        {
            var attendances = db.Attendance.Where(a => a.Date >= startDate && a.Date <= endDate);

            double avgService = db.Attendance.Where(a => a.Date >= startDate && a.Date <= endDate).Average(avg => avg.Service);
            ViewBag.AvgService = Math.Round(avgService, 1);

            double avgSundaySchool = db.Attendance.Where(a => a.Date >= startDate && a.Date <= endDate).Average(avg => avg.SundaySchool);
            ViewBag.AvgSundaySchool = Math.Round(avgSundaySchool,1);

            double avgGuest = db.Attendance.Where(a => a.Date >= startDate && a.Date <= endDate).Average(avg => avg.Guest);
            ViewBag.AvgGuest = Math.Round(avgGuest,1);

            double avgTotal = db.Attendance.Where(a => a.Date >= startDate && a.Date <= endDate).Average(avg => avg.Total);
            ViewBag.AvgTotal = Math.Round(avgTotal,1);

            return View(attendances);
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                attendance.Total = attendance.Service + attendance.SundaySchool + attendance.Guest;

                db.Attendance.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Service,SundaySchool,Guest,Date")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendance.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendance.Find(id);
            db.Attendance.Remove(attendance);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
