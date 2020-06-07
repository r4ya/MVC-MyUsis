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
    public class StudentLessons1Controller : Controller
    {
        private usis db = new usis();

        // GET: StudentLessons1
        public ActionResult Index()
        {
            var studentLessons = db.StudentLessons.Include(s => s.Course).Include(s => s.Lecturer).Include(s => s.Student);
            return View(studentLessons.ToList());
        }

        // GET: StudentLessons1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLesson studentLesson = db.StudentLessons.Find(id);
            if (studentLesson == null)
            {
                return HttpNotFound();
            }
            return View(studentLesson);
        }

        // GET: StudentLessons1/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentLessons1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentLesson1,CourseID,LetterNote,LecturerID,StudentID")] StudentLesson studentLesson)
        {
            if (ModelState.IsValid)
            {
                db.StudentLessons.Add(studentLesson);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentLesson.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentLesson.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLesson.StudentID);
            return View(studentLesson);
        }

        // GET: StudentLessons1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLesson studentLesson = db.StudentLessons.Find(id);
            if (studentLesson == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentLesson.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentLesson.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLesson.StudentID);
            return View(studentLesson);
        }

        // POST: StudentLessons1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentLesson1,CourseID,LetterNote,LecturerID,StudentID")] StudentLesson studentLesson)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentLesson).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentLesson.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentLesson.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentLesson.StudentID);
            return View(studentLesson);
        }

        // GET: StudentLessons1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentLesson studentLesson = db.StudentLessons.Find(id);
            if (studentLesson == null)
            {
                return HttpNotFound();
            }
            return View(studentLesson);
        }

        // POST: StudentLessons1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentLesson studentLesson = db.StudentLessons.Find(id);
            db.StudentLessons.Remove(studentLesson);
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
