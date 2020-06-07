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
    public class StudentLogins1Controller : Controller
    {
        private usis db = new usis();

        // GET: StudentLogins1
        public ActionResult Index()
        {
            var studentLogins = db.StudentLogins.Include(s => s.Student);
            return View(studentLogins.ToList());
        }

        // GET: StudentLogins1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            return View(studentLogin);
        }

        // GET: StudentLogins1/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentLogins1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentLoginID,StudentID,UserName,Password,Mail")] StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                db.StudentLogins.Add(studentLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLogin.StudentID);
            return View(studentLogin);
        }

        // GET: StudentLogins1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLogin.StudentID);
            return View(studentLogin);
        }

        // POST: StudentLogins1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentLoginID,StudentID,UserName,Password,Mail")] StudentLogin studentLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLogin.StudentID);
            return View(studentLogin);
        }

        // GET: StudentLogins1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            if (studentLogin == null)
            {
                return HttpNotFound();
            }
            return View(studentLogin);
        }

        // POST: StudentLogins1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLogin studentLogin = db.StudentLogins.Find(id);
            db.StudentLogins.Remove(studentLogin);
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
