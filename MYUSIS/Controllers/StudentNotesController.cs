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
    public class StudentNotesController : Controller
    {
        private usis db = new usis();

        // GET: StudentNotes
        public ActionResult Index()
        {
            var studentNotes = db.StudentNotes.Include(s => s.Student);
            return View(studentNotes.ToList());
        }

        // GET: StudentNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentNote studentNote = db.StudentNotes.Find(id);
            if (studentNote == null)
            {
                return HttpNotFound();
            }
            return View(studentNote);
        }

        // GET: StudentNotes/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName");
            return View();
        }

        // POST: StudentNotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentNoteID,StudentID,Agno,AgnoKredi,Yano,YanoKredi,CadYano,CadYanoKredi")] StudentNote studentNote)
        {
            if (ModelState.IsValid)
            {
                db.StudentNotes.Add(studentNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentNote.StudentID);
            return View(studentNote);
        }

        // GET: StudentNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentNote studentNote = db.StudentNotes.Find(id);
            if (studentNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentNote.StudentID);
            return View(studentNote);
        }

        // POST: StudentNotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentNoteID,StudentID,Agno,AgnoKredi,Yano,YanoKredi,CadYano,CadYanoKredi")] StudentNote studentNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FullName", studentNote.StudentID);
            return View(studentNote);
        }

        // GET: StudentNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentNote studentNote = db.StudentNotes.Find(id);
            if (studentNote == null)
            {
                return HttpNotFound();
            }
            return View(studentNote);
        }

        // POST: StudentNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentNote studentNote = db.StudentNotes.Find(id);
            db.StudentNotes.Remove(studentNote);
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
