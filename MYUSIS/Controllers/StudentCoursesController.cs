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
    public class StudentCoursesController : Controller
    {
        private usis db = new usis();

        // GET: StudentCourses
        public ActionResult Index()
        {
            var studentCourses = db.StudentCourses.Include(s => s.Course).Include(s => s.Day).Include(s => s.FinishTime).Include(s => s.Lecturer).Include(s => s.StartingTime).Include(s => s.Student);
            return View(studentCourses.ToList());
        }

        // GET: StudentCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // GET: StudentCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName");
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentCourseID,StudentID,CourseID,LecturerID,Classroom,DayID,StartingTimeID,FinishTimeID")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.StudentCourses.Add(studentCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", studentCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", studentCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", studentCourse.StartingTimeID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentCourse.StudentID);
            return View(studentCourse);
        }

        // GET: StudentCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", studentCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", studentCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", studentCourse.StartingTimeID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentCourse.StudentID);
            return View(studentCourse);
        }

        // POST: StudentCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentCourseID,StudentID,CourseID,LecturerID,Classroom,DayID,StartingTimeID,FinishTimeID")] StudentCourse studentCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", studentCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", studentCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", studentCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", studentCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", studentCourse.StartingTimeID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentCourse.StudentID);
            return View(studentCourse);
        }

        // GET: StudentCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            if (studentCourse == null)
            {
                return HttpNotFound();
            }
            return View(studentCourse);
        }

        // POST: StudentCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentCourse studentCourse = db.StudentCourses.Find(id);
            db.StudentCourses.Remove(studentCourse);
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
