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
    public class HullMaterialController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /HullMaterial/
        public ActionResult Index()
        {
            return View(db.HullMaterials.OrderBy(s=> s.HullMaterial1).ToList());
        }

        // GET: /HullMaterial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HullMaterial hullmaterial = db.HullMaterials.Find(id);
            if (hullmaterial == null)
            {
                return HttpNotFound();
            }
            return View(hullmaterial);
        }

        // GET: /HullMaterial/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HullMaterial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,HullMaterial1")] HullMaterial hullmaterial)
        {
            if (ModelState.IsValid)
            {
                db.HullMaterials.Add(hullmaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hullmaterial);
        }

        // GET: /HullMaterial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HullMaterial hullmaterial = db.HullMaterials.Find(id);
            if (hullmaterial == null)
            {
                return HttpNotFound();
            }
            return View(hullmaterial);
        }

        // POST: /HullMaterial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,HullMaterial1")] HullMaterial hullmaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hullmaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hullmaterial);
        }

        // GET: /HullMaterial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HullMaterial hullmaterial = db.HullMaterials.Find(id);
            if (hullmaterial == null)
            {
                return HttpNotFound();
            }
            return View(hullmaterial);
        }

        // POST: /HullMaterial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HullMaterial hullmaterial = db.HullMaterials.Find(id);
            db.HullMaterials.Remove(hullmaterial);
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
