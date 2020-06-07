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
    public class StudentInfoesController : Controller
    {
        private usis db = new usis();

        // GET: StudentInfoes
        public ActionResult Index()
        {
            var studentInfoes = db.StudentInfoes.Include(s => s.Student);
            return View(studentInfoes.ToList());
        }

        // GET: StudentInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // GET: StudentInfoes/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentInfoID,StudentID,MotherName,FatherName,BirthPlace,Nationality,Gender,City,County")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfoes.Add(studentInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentInfo.StudentID);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentInfo.StudentID);
            return View(studentInfo);
        }

        // POST: StudentInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentInfoID,StudentID,MotherName,FatherName,BirthPlace,Nationality,Gender,City,County")] StudentInfo studentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentInfo.StudentID);
            return View(studentInfo);
        }

        // GET: StudentInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            if (studentInfo == null)
            {
                return HttpNotFound();
            }
            return View(studentInfo);
        }

        // POST: StudentInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentInfo studentInfo = db.StudentInfoes.Find(id);
            db.StudentInfoes.Remove(studentInfo);
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
