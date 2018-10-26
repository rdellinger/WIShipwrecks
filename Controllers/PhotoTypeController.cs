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
    public class PhotoTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /PhotoType/
        public ActionResult Index()
        {
            return View(db.PhotoTypes.OrderBy(s=> s.PhotoType1).ToList());
        }

        // GET: /PhotoType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType phototype = db.PhotoTypes.Find(id);
            if (phototype == null)
            {
                return HttpNotFound();
            }
            return View(phototype);
        }

        // GET: /PhotoType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PhotoType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,PhotoType1")] PhotoType phototype)
        {
            if (ModelState.IsValid)
            {
                db.PhotoTypes.Add(phototype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phototype);
        }

        // GET: /PhotoType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType phototype = db.PhotoTypes.Find(id);
            if (phototype == null)
            {
                return HttpNotFound();
            }
            return View(phototype);
        }

        // POST: /PhotoType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,PhotoType1")] PhotoType phototype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phototype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phototype);
        }

        // GET: /PhotoType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoType phototype = db.PhotoTypes.Find(id);
            if (phototype == null)
            {
                return HttpNotFound();
            }
            return View(phototype);
        }

        // POST: /PhotoType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoType phototype = db.PhotoTypes.Find(id);
            db.PhotoTypes.Remove(phototype);
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
