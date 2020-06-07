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
    public class StartingTimesController : Controller
    {
        private usis db = new usis();

        // GET: StartingTimes
        public ActionResult Index()
        {
            return View(db.StartingTimes.ToList());
        }

        // GET: StartingTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StartingTime startingTime = db.StartingTimes.Find(id);
            if (startingTime == null)
            {
                return HttpNotFound();
            }
            return View(startingTime);
        }

        // GET: StartingTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StartingTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StartingTimeID,StatingTime")] StartingTime startingTime)
        {
            if (ModelState.IsValid)
            {
                db.StartingTimes.Add(startingTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(startingTime);
        }

        // GET: StartingTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StartingTime startingTime = db.StartingTimes.Find(id);
            if (startingTime == null)
            {
                return HttpNotFound();
            }
            return View(startingTime);
        }

        // POST: StartingTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StartingTimeID,StatingTime")] StartingTime startingTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(startingTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(startingTime);
        }

        // GET: StartingTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StartingTime startingTime = db.StartingTimes.Find(id);
            if (startingTime == null)
            {
                return HttpNotFound();
            }
            return View(startingTime);
        }

        // POST: StartingTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StartingTime startingTime = db.StartingTimes.Find(id);
            db.StartingTimes.Remove(startingTime);
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
