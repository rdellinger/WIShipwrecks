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
    public class VideoTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VideoType/
        public ActionResult Index()
        {
            return View(db.VideoTypes.ToList());
        }

        // GET: /VideoType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoType videoType = db.VideoTypes.Find(id);
            if (videoType == null)
            {
                return HttpNotFound();
            }
            return View(videoType);
        }

        // GET: /VideoType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VideoType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,VideoType1")] VideoType videoType)
        {
            if (ModelState.IsValid)
            {
                db.VideoTypes.Add(videoType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoType);
        }

        // GET: /VideoType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoType videoType = db.VideoTypes.Find(id);
            if (videoType == null)
            {
                return HttpNotFound();
            }
            return View(videoType);
        }

        // POST: /VideoType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,VideoType1")] VideoType videoType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoType);
        }

        // GET: /VideoType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoType videoType = db.VideoTypes.Find(id);
            if (videoType == null)
            {
                return HttpNotFound();
            }
            return View(videoType);
        }

        // POST: /VideoType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoType videoType = db.VideoTypes.Find(id);
            db.VideoTypes.Remove(videoType);
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
