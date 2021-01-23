using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Authorize]
    public class ParentController : Controller
    {
        //Attributes
        private DatabaseEntities db = new DatabaseEntities();
        private IRepository<Parent> rp;

        //Constructor
        public ParentController()
        {
            rp = new ParentRepository();
        }

        public ParentController(IRepository<Parent> repository)
        {
            rp = repository;
        }
        // GET: Parent
        public ActionResult Index()
        {
            var parents = db.Parents.Include(p => p.Family);
            return View(parents.ToList());
        }

        // GET: Parent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = rp.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // GET: Parent/Create
        public ActionResult Create()
        {
            ViewBag.FamilyId = new SelectList((from f in db.Families select new { familyId = f.FamilyId, familyDetail = f.AddressLine + ", " + f.AddressPostcode }), "FamilyId", "familyDetail");
            return View();
        }

        // POST: Parent/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParentId,FamilyId,Firstname,Lastname,DateOfBirth,Gender")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                rp.Add(parent);
                return RedirectToAction("Index");
            }

            ViewBag.FamilyId = new SelectList(db.Families, "familyId", "ContactNumber", parent.FamilyId);
            return View(parent);
        }

        // GET: Parent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = rp.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            ViewBag.FamilyId = new SelectList((from f in db.Families select new { familyId = f.FamilyId, familyDetail = f.AddressLine + ", " + f.AddressPostcode }), "FamilyId", "familyDetail");
            return View(parent);
        }

        // POST: Parent/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParentId,FamilyId,Firstname,Lastname,DateOfBirth,Gender")] Parent parent)
        {
            if (ModelState.IsValid)
            {
                rp.Update(parent);
                return RedirectToAction("Index");
            }
            ViewBag.FamilyId = new SelectList(db.Families, "FamilyId", "ContactNumber", parent.FamilyId);
            return View(parent);
        }

        // GET: Parent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = rp.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            return View(parent);
        }

        // POST: Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parent parent = rp.Find(id);
            rp.Delete(parent.ParentId);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Parent/Archive/5
        public ActionResult Archive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parent parent = rp.Find(id);
            if (parent == null)
            {
                return HttpNotFound();
            }
            Archive archive = new Archive
            {
                DateOfBirth = parent.DateOfBirth,
                Firstname = parent.Firstname,
                Lastname = parent.Lastname,
                Gender = parent.Gender,
                Type = "Parent"
            };
            db.Archives.Add(archive);
            db.Parents.Remove(parent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rp.Dispose();
            }
            base.Dispose(disposing);
        }

        [AllowAnonymous]
        public ActionResult ParentIndex(int? id)
        {
            var parents = db.Parents.Include(p => p.Family);
            var parent = parents.Where(p => p.ParentId == id);
            return View(parent);
        }
    }
}
