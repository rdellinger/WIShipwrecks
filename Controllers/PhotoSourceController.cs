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
    public class PhotoSourceController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /PhotoSource/
        public ActionResult Index()
        {
            return View(db.PhotoSources.OrderBy(s=> s.Source).ToList());
        }

        // GET: /PhotoSource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoSource photosource = db.PhotoSources.Find(id);
            if (photosource == null)
            {
                return HttpNotFound();
            }
            return View(photosource);
        }

        // GET: /PhotoSource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /PhotoSource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Source,URL")] PhotoSource photosource)
        {
            if (ModelState.IsValid)
            {
                db.PhotoSources.Add(photosource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photosource);
        }

        // GET: /PhotoSource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoSource photosource = db.PhotoSources.Find(id);
            if (photosource == null)
            {
                return HttpNotFound();
            }
            return View(photosource);
        }

        // POST: /PhotoSource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Source,URL")] PhotoSource photosource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photosource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photosource);
        }

        // GET: /PhotoSource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhotoSource photosource = db.PhotoSources.Find(id);
            if (photosource == null)
            {
                return HttpNotFound();
            }
            return View(photosource);
        }

        // POST: /PhotoSource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhotoSource photosource = db.PhotoSources.Find(id);
            db.PhotoSources.Remove(photosource);
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
