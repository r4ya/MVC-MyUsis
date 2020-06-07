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
    public class LecturerCoursesController : Controller
    {
        private usis db = new usis();

        // GET: LecturerCourses
        public ActionResult Index()
        {
            var lecturerCourses = db.LecturerCourses.Include(l => l.Course).Include(l => l.Day).Include(l => l.FinishTime).Include(l => l.Lecturer).Include(l => l.StartingTime);
            return View(lecturerCourses.ToList());
        }

        // GET: LecturerCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturerCourse lecturerCourse = db.LecturerCourses.Find(id);
            if (lecturerCourse == null)
            {
                return HttpNotFound();
            }
            return View(lecturerCourse);
        }

        // GET: LecturerCourses/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName");
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName");
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1");
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName");
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime");
            return View();
        }

        // POST: LecturerCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LecturerCourseID,CourseID,LecturerID,Classroom,DayID,StartingTimeID,FinishTimeID")] LecturerCourse lecturerCourse)
        {
            if (ModelState.IsValid)
            {
                db.LecturerCourses.Add(lecturerCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", lecturerCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", lecturerCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", lecturerCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", lecturerCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", lecturerCourse.StartingTimeID);
            return View(lecturerCourse);
        }

        // GET: LecturerCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturerCourse lecturerCourse = db.LecturerCourses.Find(id);
            if (lecturerCourse == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", lecturerCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", lecturerCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", lecturerCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", lecturerCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", lecturerCourse.StartingTimeID);
            return View(lecturerCourse);
        }

        // POST: LecturerCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LecturerCourseID,CourseID,LecturerID,Classroom,DayID,StartingTimeID,FinishTimeID")] LecturerCourse lecturerCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturerCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "CourseName", lecturerCourse.CourseID);
            ViewBag.DayID = new SelectList(db.Days, "DayID", "DayName", lecturerCourse.DayID);
            ViewBag.FinishTimeID = new SelectList(db.FinishTimes, "FinishTimeID", "FinishTime1", lecturerCourse.FinishTimeID);
            ViewBag.LecturerID = new SelectList(db.Lecturers, "LecturerID", "FullName", lecturerCourse.LecturerID);
            ViewBag.StartingTimeID = new SelectList(db.StartingTimes, "StartingTimeID", "StatingTime", lecturerCourse.StartingTimeID);
            return View(lecturerCourse);
        }

        // GET: LecturerCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LecturerCourse lecturerCourse = db.LecturerCourses.Find(id);
            if (lecturerCourse == null)
            {
                return HttpNotFound();
            }
            return View(lecturerCourse);
        }

        // POST: LecturerCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LecturerCourse lecturerCourse = db.LecturerCourses.Find(id);
            db.LecturerCourses.Remove(lecturerCourse);
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
