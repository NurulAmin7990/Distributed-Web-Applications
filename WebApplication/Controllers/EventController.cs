using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Event
        public ActionResult Index()
        {
            var events = db.Events.Include(a => a.Meet);
            return View(events.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            ViewBag.MeetId = new SelectList((from m in db.Meets select new {meetId = m.MeetId, meetDetail = m.Name + ", " + m.Venue}), "MeetId", "meetDetail");
            ViewBag.Strokes = new List<SelectListItem>() { 
                new SelectListItem{Text = "Front Crawl", Value = "Front crawl" },
                new SelectListItem{Text = "Backstroke", Value = "Backstroke" },
                new SelectListItem{Text = "Breaststroke", Value = "Breaststroke" },
                new SelectListItem{Text = "Butterfly", Value = "Butterfly" },
                new SelectListItem{Text = "Sidestroke", Value = "Sidestroke" },
                new SelectListItem{Text = "Elementary Backstroke", Value = "Elementary backstroke" },
                new SelectListItem{Text = "Combat Side Stroke", Value = "Combat side stroke" },
                new SelectListItem{Text = "Trudgen", Value = "Trudgen" }
                };
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,MeetId,AgeRange,Gender,Distance,Stroke,Round,StartTime,EndTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MeetId = new SelectList(db.Meets, "MeetId", "Name", @event.MeetId);
            return View(@event);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.MeetId = new SelectList((from m in db.Meets select new { meetId = m.MeetId, meetDetail = m.Name + ", " + m.Venue }), "MeetId", "meetDetail");
            ViewBag.Strokes = new List<SelectListItem>() {
                new SelectListItem{Text = "Front Crawl", Value = "Front crawl" },
                new SelectListItem{Text = "Backstroke", Value = "Backstroke" },
                new SelectListItem{Text = "Breaststroke", Value = "Breaststroke" },
                new SelectListItem{Text = "Butterfly", Value = "Butterfly" },
                new SelectListItem{Text = "Sidestroke", Value = "Sidestroke" },
                new SelectListItem{Text = "Elementary Backstroke", Value = "Elementary backstroke" },
                new SelectListItem{Text = "Combat Side Stroke", Value = "Combat side stroke" },
                new SelectListItem{Text = "Trudgen", Value = "Trudgen" }
                };
            return View(@event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,MeetId,AgeRange,Gender,Distance,Stroke,Round,StartTime,EndTime")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MeetId = new SelectList(db.Meets, "MeetId", "Name", @event.MeetId);
            return View(@event);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
