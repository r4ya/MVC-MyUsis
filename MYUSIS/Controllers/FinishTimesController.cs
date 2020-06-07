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
    public class FinishTimesController : Controller
    {
        private usis db = new usis();

        // GET: FinishTimes
        public ActionResult Index()
        {
            return View(db.FinishTimes.ToList());
        }

        // GET: FinishTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishTime finishTime = db.FinishTimes.Find(id);
            if (finishTime == null)
            {
                return HttpNotFound();
            }
            return View(finishTime);
        }

        // GET: FinishTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinishTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FinishTimeID,FinishTime1")] FinishTime finishTime)
        {
            if (ModelState.IsValid)
            {
                db.FinishTimes.Add(finishTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finishTime);
        }

        // GET: FinishTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishTime finishTime = db.FinishTimes.Find(id);
            if (finishTime == null)
            {
                return HttpNotFound();
            }
            return View(finishTime);
        }

        // POST: FinishTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FinishTimeID,FinishTime1")] FinishTime finishTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finishTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finishTime);
        }

        // GET: FinishTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinishTime finishTime = db.FinishTimes.Find(id);
            if (finishTime == null)
            {
                return HttpNotFound();
            }
            return View(finishTime);
        }

        // POST: FinishTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FinishTime finishTime = db.FinishTimes.Find(id);
            db.FinishTimes.Remove(finishTime);
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
