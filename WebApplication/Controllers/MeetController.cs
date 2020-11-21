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
    public class MeetController : Controller
    {
        private DatabaseEntities db = new DatabaseEntities();

        // GET: Meet
        public ActionResult Index()
        {
            return View(db.Meets.ToList());
        }

        // GET: Meet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        // GET: Meet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MeetId,Name,Venue,Date,PoolLength")] Meet meet)
        {
            if (ModelState.IsValid)
            {
                db.Meets.Add(meet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meet);
        }

        // GET: Meet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        // POST: Meet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MeetId,Name,Venue,Date,PoolLength")] Meet meet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meet);
        }

        // GET: Meet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meet meet = db.Meets.Find(id);
            if (meet == null)
            {
                return HttpNotFound();
            }
            return View(meet);
        }

        // POST: Meet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meet meet = db.Meets.Find(id);
            db.Meets.Remove(meet);
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
