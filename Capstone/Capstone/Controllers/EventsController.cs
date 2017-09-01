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
    public class EventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly Event _event;

        public EventsController()
        {
            _event = new Event();
        }

        // GET: Events
        public ActionResult Index()
        {
            return View(db.Event.ToList());
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult GetEvents(/*double start, double end*/)
        {
            //var startDateTime = FromUnixTimestamp(start);
            //var endDateTime = FromUnixTimestamp(end);

            var events = db.Event.ToList();
            //var newevent = events.GetEvents(startDateTime, endDateTime);
            //var events = GetEvents();
            var eventList = new List<object>();

            foreach (var e in events)
            {
                var Start = e.Start.ToString("s");
                var End = e.End.ToString("s");

                eventList.Add(
                    new
                    {
                        id = e.ID,
                        title = e.Name,
                        description = e.Description,
                        start = Start,
                        end = End,
                        allDay = e.AllDay,
                    });
            }
            return Json(eventList.ToArray(), JsonRequestBehavior.AllowGet);
        }

        private static DateTime FromUnixTimestamp(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }

        //public ActionResult GetEvents(double start, double end)
        //{
        //    var fromDate = ConvertFromUnixTimestamp(start);
        //    var toDate = ConvertFromUnixTimestamp(end);

        //    //Get the events
        //    //You may get from the repository also
        //    var eventList = GetEvents();

        //    var rows = eventList.ToArray();
        //    return Json(rows, JsonRequestBehavior.AllowGet);
        //}

        //private List<Event> GetEvents()
        //{
        //    List<Event> eventList = new List<Event>();

        //    Event newEvent = new Event
        //    {
        //        EventID = "1",
        //        Name = "Event 1",
        //        Start = DateTime.Now.AddDays(1).ToString("s"),
        //        End = DateTime.Now.AddDays(1).ToString("s"),
        //        AllDay = false
        //    };

        //    eventList.Add(newEvent);

        //    newEvent = new Event
        //    {
        //        EventID = "1",
        //        Name = "Event 3",
        //        Start = DateTime.Now.AddDays(2).ToString("s"),
        //        End = DateTime.Now.AddDays(3).ToString("s"),
        //        AllDay = false
        //    };

        //    eventList.Add(newEvent);

        //    return eventList;
        //}

        //private static DateTime ConvertFromUnixTimestamp(double timestamp)
        //{
        //    var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        //    return origin.AddSeconds(timestamp);
        //}

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Start,End,ThemeColor")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Event.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Start,End,ThemeColor")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Event.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Event.Find(id);
            db.Event.Remove(@event);
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
