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
    public class PropulsionTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /PropulsionType/
        public ActionResult Index()
        {
            return View(db.PropulsionTypes.OrderBy(s=> s.PropulsionType1).ToList());
        }

        // GET: /PropulsionType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropulsionType propulsiontype = db.PropulsionTypes.Find(id);
            if (propulsiontype == null)
            {
                return HttpNotFound();
            }
            return View(propulsiontype);
        }

        // GET: /PropulsionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PropulsionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PropulsionType1")] PropulsionType propulsiontype)
        {
            if (ModelState.IsValid)
            {
                db.PropulsionTypes.Add(propulsiontype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propulsiontype);
        }

        // GET: /PropulsionType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropulsionType propulsiontype = db.PropulsionTypes.Find(id);
            if (propulsiontype == null)
            {
                return HttpNotFound();
            }
            return View(propulsiontype);
        }

        // POST: /PropulsionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PropulsionType1")] PropulsionType propulsiontype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propulsiontype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propulsiontype);
        }

        // GET: /PropulsionType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PropulsionType propulsiontype = db.PropulsionTypes.Find(id);
            if (propulsiontype == null)
            {
                return HttpNotFound();
            }
            return View(propulsiontype);
        }

        // POST: /PropulsionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PropulsionType propulsiontype = db.PropulsionTypes.Find(id);
            db.PropulsionTypes.Remove(propulsiontype);
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
