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
    public class VesselTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VesselType/
        public ActionResult Index()
        {
            return View(db.VesselTypes.OrderBy(s=> s.VesselType1).ToList());
        }

        // GET: /VesselType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselType vesseltype = db.VesselTypes.Find(id);
            if (vesseltype == null)
            {
                return HttpNotFound();
            }
            return View(vesseltype);
        }

        // GET: /VesselType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VesselType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,VesselType1")] VesselType vesseltype)
        {
            if (ModelState.IsValid)
            {
                db.VesselTypes.Add(vesseltype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vesseltype);
        }

        // GET: /VesselType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselType vesseltype = db.VesselTypes.Find(id);
            if (vesseltype == null)
            {
                return HttpNotFound();
            }
            return View(vesseltype);
        }

        // POST: /VesselType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,VesselType1")] VesselType vesseltype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vesseltype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vesseltype);
        }

        // GET: /VesselType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselType vesseltype = db.VesselTypes.Find(id);
            if (vesseltype == null)
            {
                return HttpNotFound();
            }
            return View(vesseltype);
        }

        // POST: /VesselType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VesselType vesseltype = db.VesselTypes.Find(id);
            db.VesselTypes.Remove(vesseltype);
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
