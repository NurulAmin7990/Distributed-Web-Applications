using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize(Roles = "admin")]
    public class ParticipantController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Participant
        public ActionResult Index()
        {
            var participants = db.Participants.Include(p => p.Child).Include(p => p.Event);
            return View(participants.ToList());
        }

        // GET: Participant/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // GET: Participant/Create
        public ActionResult Create()
        {
            ViewBag.ChildrenId = new SelectList(db.Children.Where(c => c.Permission == true), "ChildrenId", "Firstname");
            ViewBag.EventId = new SelectList((from e in db.Events select new { eventId = e.EventId, e.Meet.Name }), "EventId", "Name");
            return View();
        }

        // POST: Participant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipantId,EventId,ChildrenId,Lane,Time")] Participant participant)
        {

            if (ModelState.IsValid)
                {
                    db.Participants.Add(participant);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            ViewBag.ChildrenId = new SelectList(db.Children.Where(c => c.Permission == true), "ChildrenId", "Firstname", participant.ChildrenId);
            ViewBag.EventId = new SelectList((from e in db.Events select new { eventId = e.EventId, e.Meet.Name }), "EventId", "Name", participant.EventId);
            return View(participant);
        }

        // GET: Participant/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildrenId = new SelectList(db.Children.Where(c => c.Permission == true), "ChildrenId", "Firstname", participant.ChildrenId);
            ViewBag.EventId = new SelectList((from e in db.Events select new { eventId = e.EventId, e.Meet.Name }), "EventId", "Name", participant.EventId);
            return View(participant);
        }

        // POST: Participant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipantId,EventId,ChildrenId,Lane,Time")] Participant participant)
        {


            if (ModelState.IsValid)
            {
                    db.Entry(participant).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
            }
            ViewBag.ChildrenId = new SelectList(db.Children.Where(c => c.Permission == true), "ChildrenId", "Firstname", participant.ChildrenId);
            ViewBag.EventId = new SelectList((from e in db.Events select new { eventId = e.EventId, e.Meet.Name }), "EventId", "Name", participant.EventId);
            return View(participant);
        }

        // GET: Participant/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
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
