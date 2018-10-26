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
    public class LocationPotentialController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /LocationPotential/
        public ActionResult Index()
        {
            return View(db.LocationPotentials.ToList());
        }

        // GET: /LocationPotential/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationPotential locationpotential = db.LocationPotentials.Find(id);
            if (locationpotential == null)
            {
                return HttpNotFound();
            }
            return View(locationpotential);
        }

        // GET: /LocationPotential/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /LocationPotential/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,LocationPotential1")] LocationPotential locationpotential)
        {
            if (ModelState.IsValid)
            {
                db.LocationPotentials.Add(locationpotential);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(locationpotential);
        }

        // GET: /LocationPotential/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationPotential locationpotential = db.LocationPotentials.Find(id);
            if (locationpotential == null)
            {
                return HttpNotFound();
            }
            return View(locationpotential);
        }

        // POST: /LocationPotential/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,LocationPotential1")] LocationPotential locationpotential)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locationpotential).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(locationpotential);
        }

        // GET: /LocationPotential/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LocationPotential locationpotential = db.LocationPotentials.Find(id);
            if (locationpotential == null)
            {
                return HttpNotFound();
            }
            return View(locationpotential);
        }

        // POST: /LocationPotential/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LocationPotential locationpotential = db.LocationPotentials.Find(id);
            db.LocationPotentials.Remove(locationpotential);
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
