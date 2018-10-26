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
    public class RigTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /RigType/
        public ActionResult Index()
        {
            return View(db.RigTypes.OrderBy(s=> s.RigType1).ToList());
        }

        // GET: /RigType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RigType rigtype = db.RigTypes.Find(id);
            if (rigtype == null)
            {
                return HttpNotFound();
            }
            return View(rigtype);
        }

        // GET: /RigType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /RigType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,RigType1")] RigType rigtype)
        {
            if (ModelState.IsValid)
            {
                db.RigTypes.Add(rigtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rigtype);
        }

        // GET: /RigType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RigType rigtype = db.RigTypes.Find(id);
            if (rigtype == null)
            {
                return HttpNotFound();
            }
            return View(rigtype);
        }

        // POST: /RigType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,RigType1")] RigType rigtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rigtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rigtype);
        }

        // GET: /RigType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RigType rigtype = db.RigTypes.Find(id);
            if (rigtype == null)
            {
                return HttpNotFound();
            }
            return View(rigtype);
        }

        // POST: /RigType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RigType rigtype = db.RigTypes.Find(id);
            db.RigTypes.Remove(rigtype);
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
