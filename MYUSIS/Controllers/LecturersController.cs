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
    public class LecturersController : Controller
    {
        private usis db = new usis();

        // GET: Lecturers
        public ActionResult Index()
        {
            var lecturers = db.Lecturers.Include(l => l.Department).Include(l => l.Faculty);
            return View(lecturers.ToList());
        }

        // GET: Lecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LecturerID,Title,FullName,FacultyID,DepartmentID,UserName,Password,Mail")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", lecturer.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", lecturer.FacultyID);
            return View(lecturer);
        }

        // GET: Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", lecturer.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", lecturer.FacultyID);
            return View(lecturer);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LecturerID,Title,FullName,FacultyID,DepartmentID,UserName,Password,Mail")] Lecturer lecturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", lecturer.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", lecturer.FacultyID);
            return View(lecturer);
        }

        // GET: Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturer lecturer = db.Lecturers.Find(id);
            if (lecturer == null)
            {
                return HttpNotFound();
            }
            return View(lecturer);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturer lecturer = db.Lecturers.Find(id);
            db.Lecturers.Remove(lecturer);
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
