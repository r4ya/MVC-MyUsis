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
    public class Students2Controller : Controller
    {
        private usis db = new usis();

        // GET: Students2
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Department).Include(s => s.Faculty).Include(s => s.Lecturer);
            return View(students.ToList());
        }

        // GET: Students2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students2/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            return View();
        }

        // POST: Students2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FullName,Number,FacultyID,DepartmentID,LecturerID,Status,TCKN,Class,Period,RegistryType,RegistryDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", student.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // GET: Students2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", student.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // POST: Students2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FullName,Number,FacultyID,DepartmentID,LecturerID,Status,TCKN,Class,Period,RegistryType,RegistryDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", student.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", student.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", student.LecturerID);
            return View(student);
        }

        // GET: Students2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
