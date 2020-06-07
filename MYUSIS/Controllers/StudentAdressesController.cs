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
    public class StudentAdressesController : Controller
    {
        private usis db = new usis();

        // GET: StudentAdresses
        public ActionResult Index()
        {
            var studentAdresses = db.StudentAdresses.Include(s => s.Student);
            return View(studentAdresses.ToList());
        }

        // GET: StudentAdresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdress studentAdress = db.StudentAdresses.Find(id);
            if (studentAdress == null)
            {
                return HttpNotFound();
            }
            return View(studentAdress);
        }

        // GET: StudentAdresses/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentAdresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentAdressID,StudentID,PK,Adress,County,City,Telephone")] StudentAdress studentAdress)
        {
            if (ModelState.IsValid)
            {
                db.StudentAdresses.Add(studentAdress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentAdress.StudentID);
            return View(studentAdress);
        }

        // GET: StudentAdresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdress studentAdress = db.StudentAdresses.Find(id);
            if (studentAdress == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentAdress.StudentID);
            return View(studentAdress);
        }

        // POST: StudentAdresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentAdressID,StudentID,PK,Adress,County,City,Telephone")] StudentAdress studentAdress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAdress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentAdress.StudentID);
            return View(studentAdress);
        }

        // GET: StudentAdresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAdress studentAdress = db.StudentAdresses.Find(id);
            if (studentAdress == null)
            {
                return HttpNotFound();
            }
            return View(studentAdress);
        }

        // POST: StudentAdresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAdress studentAdress = db.StudentAdresses.Find(id);
            db.StudentAdresses.Remove(studentAdress);
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
