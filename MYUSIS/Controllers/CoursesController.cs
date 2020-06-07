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
    public class CoursesController : Controller
    {
        private usis db = new usis();

        // GET: Courses
        public ActionResult Index()
        {
            var courses = db.Courses.Include(c => c.Department).Include(c => c.Faculty).Include(c => c.Lecturer);
            return View(courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName");
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,CourseName,CourseCode,LecturerID,FacultyID,DepartmentID,Semester,CourseType,T,U,L,K,E,Precond")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", course.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", course.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", course.LecturerID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", course.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", course.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", course.LecturerID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,CourseName,CourseCode,LecturerID,FacultyID,DepartmentID,Semester,CourseType,T,U,L,K,E,Precond")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmenName", course.DepartmentID);
            ViewBag.FacultyID = new SelectList(db.Faculties, "FacultyID", "FacultyName", course.FacultyID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", course.LecturerID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
