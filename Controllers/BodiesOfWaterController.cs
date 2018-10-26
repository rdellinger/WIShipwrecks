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
    public class BodiesOfWaterController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /BodiesOfWater/
        public ActionResult Index()
        {
            return View(db.BodiesOfWaters.OrderBy(s=> s.BodyOfWater).ToList());
        }

        // GET: /BodiesOfWater/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodiesOfWater bodiesofwater = db.BodiesOfWaters.Find(id);
            if (bodiesofwater == null)
            {
                return HttpNotFound();
            }
            return View(bodiesofwater);
        }

        // GET: /BodiesOfWater/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BodiesOfWater/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,BodyOfWater")] BodiesOfWater bodiesofwater)
        {
            if (ModelState.IsValid)
            {
                db.BodiesOfWaters.Add(bodiesofwater);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bodiesofwater);
        }

        // GET: /BodiesOfWater/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodiesOfWater bodiesofwater = db.BodiesOfWaters.Find(id);
            if (bodiesofwater == null)
            {
                return HttpNotFound();
            }
            return View(bodiesofwater);
        }

        // POST: /BodiesOfWater/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,BodyOfWater")] BodiesOfWater bodiesofwater)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bodiesofwater).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bodiesofwater);
        }

        // GET: /BodiesOfWater/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BodiesOfWater bodiesofwater = db.BodiesOfWaters.Find(id);
            if (bodiesofwater == null)
            {
                return HttpNotFound();
            }
            return View(bodiesofwater);
        }

        // POST: /BodiesOfWater/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BodiesOfWater bodiesofwater = db.BodiesOfWaters.Find(id);
            db.BodiesOfWaters.Remove(bodiesofwater);
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
