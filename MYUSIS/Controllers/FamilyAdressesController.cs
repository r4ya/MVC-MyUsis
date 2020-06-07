using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MYUSIS.Models;

namespace MYUSIS.Controllers
{
    public class FamilyAdressesController : Controller
    {
        private usis db = new usis();

        // GET: FamilyAdresses
        public ActionResult Index()
        {
            var familyAdresses = db.FamilyAdresses.Include(f => f.Student);
            return View(familyAdresses.ToList());
        }

        // GET: FamilyAdresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAdress familyAdress = db.FamilyAdresses.Find(id);
            if (familyAdress == null)
            {
                return HttpNotFound();
            }
            return View(familyAdress);
        }

        // GET: FamilyAdresses/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: FamilyAdresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FamilyAdressID,StudentID,Adress,Telephone,PK")] FamilyAdress familyAdress)
        {
            if (ModelState.IsValid)
            {
                db.FamilyAdresses.Add(familyAdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", familyAdress.StudentID);
            return View(familyAdress);
        }

        // GET: FamilyAdresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAdress familyAdress = db.FamilyAdresses.Find(id);
            if (familyAdress == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", familyAdress.StudentID);
            return View(familyAdress);
        }

        // POST: FamilyAdresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FamilyAdressID,StudentID,Adress,Telephone,PK")] FamilyAdress familyAdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyAdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", familyAdress.StudentID);
            return View(familyAdress);
        }

        // GET: FamilyAdresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyAdress familyAdress = db.FamilyAdresses.Find(id);
            if (familyAdress == null)
            {
                return HttpNotFound();
            }
            return View(familyAdress);
        }

        // POST: FamilyAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FamilyAdress familyAdress = db.FamilyAdresses.Find(id);
            db.FamilyAdresses.Remove(familyAdress);
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
