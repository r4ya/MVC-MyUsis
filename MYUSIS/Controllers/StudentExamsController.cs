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
    public class StudentExamsController : Controller
    {
        private usis db = new usis();

        // GET: StudentExams
        public ActionResult Index()
        {
            var studentExams = db.StudentExams.Include(s => s.Course).Include(s => s.Lecturer).Include(s => s.Student);
            return View(studentExams.ToList());
        }

        // GET: StudentExams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            return View(studentExam);
        }

        // GET: StudentExams/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentExams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentExamID,StudentID,CourseID,LecturerID,ExamOne,ExamTwo,ExamFinal,Homework,Project")] StudentExam studentExam)
        {
            if (ModelState.IsValid)
            {
                db.StudentExams.Add(studentExam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentExam.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentExam.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentExam.StudentID);
            return View(studentExam);
        }

        // GET: StudentExams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentExam.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentExam.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentExam.StudentID);
            return View(studentExam);
        }

        // POST: StudentExams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentExamID,StudentID,CourseID,LecturerID,ExamOne,ExamTwo,ExamFinal,Homework,Project")] StudentExam studentExam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentExam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentExam.CourseID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentExam.LecturerID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentExam.StudentID);
            return View(studentExam);
        }

        // GET: StudentExams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentExam studentExam = db.StudentExams.Find(id);
            if (studentExam == null)
            {
                return HttpNotFound();
            }
            return View(studentExam);
        }

        // POST: StudentExams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentExam studentExam = db.StudentExams.Find(id);
            db.StudentExams.Remove(studentExam);
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
