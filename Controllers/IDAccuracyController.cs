using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    [Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class IDAccuracyController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /IDAccuracy/
        public ActionResult Index()
        {
            return View(db.IDAccuracies.ToList());
        }

        // GET: /IDAccuracy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAccuracy idaccuracy = db.IDAccuracies.Find(id);
            if (idaccuracy == null)
            {
                return HttpNotFound();
            }
            return View(idaccuracy);
        }

        // GET: /IDAccuracy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /IDAccuracy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Accuracy")] IDAccuracy idaccuracy)
        {
            if (ModelState.IsValid)
            {
                db.IDAccuracies.Add(idaccuracy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(idaccuracy);
        }

        // GET: /IDAccuracy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAccuracy idaccuracy = db.IDAccuracies.Find(id);
            if (idaccuracy == null)
            {
                return HttpNotFound();
            }
            return View(idaccuracy);
        }

        // POST: /IDAccuracy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Accuracy")] IDAccuracy idaccuracy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(idaccuracy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(idaccuracy);
        }

        // GET: /IDAccuracy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IDAccuracy idaccuracy = db.IDAccuracies.Find(id);
            if (idaccuracy == null)
            {
                return HttpNotFound();
            }
            return View(idaccuracy);
        }

        // POST: /IDAccuracy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IDAccuracy idaccuracy = db.IDAccuracies.Find(id);
            db.IDAccuracies.Remove(idaccuracy);
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
