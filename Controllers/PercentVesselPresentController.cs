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
    public class PercentVesselPresentController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /PercentVesselPresent/
        public ActionResult Index()
        {
            return View(db.PercentVesselPresents.OrderBy(s=> s.Range).ToList());
        }

        // GET: /PercentVesselPresent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercentVesselPresent percentvesselpresent = db.PercentVesselPresents.Find(id);
            if (percentvesselpresent == null)
            {
                return HttpNotFound();
            }
            return View(percentvesselpresent);
        }

        // GET: /PercentVesselPresent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PercentVesselPresent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Range")] PercentVesselPresent percentvesselpresent)
        {
            if (ModelState.IsValid)
            {
                db.PercentVesselPresents.Add(percentvesselpresent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(percentvesselpresent);
        }

        // GET: /PercentVesselPresent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercentVesselPresent percentvesselpresent = db.PercentVesselPresents.Find(id);
            if (percentvesselpresent == null)
            {
                return HttpNotFound();
            }
            return View(percentvesselpresent);
        }

        // POST: /PercentVesselPresent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Range")] PercentVesselPresent percentvesselpresent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(percentvesselpresent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(percentvesselpresent);
        }

        // GET: /PercentVesselPresent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PercentVesselPresent percentvesselpresent = db.PercentVesselPresents.Find(id);
            if (percentvesselpresent == null)
            {
                return HttpNotFound();
            }
            return View(percentvesselpresent);
        }

        // POST: /PercentVesselPresent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PercentVesselPresent percentvesselpresent = db.PercentVesselPresents.Find(id);
            db.PercentVesselPresents.Remove(percentvesselpresent);
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
