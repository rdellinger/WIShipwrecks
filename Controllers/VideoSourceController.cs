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
    public class VideoSourceController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VideoSource/
        public ActionResult Index()
        {
            return View(db.VideoSources.ToList());
        }

        // GET: /VideoSource/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoSource videoSource = db.VideoSources.Find(id);
            if (videoSource == null)
            {
                return HttpNotFound();
            }
            return View(videoSource);
        }

        // GET: /VideoSource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /VideoSource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Source,URL")] VideoSource videoSource)
        {
            if (ModelState.IsValid)
            {
                db.VideoSources.Add(videoSource);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoSource);
        }

        // GET: /VideoSource/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoSource videoSource = db.VideoSources.Find(id);
            if (videoSource == null)
            {
                return HttpNotFound();
            }
            return View(videoSource);
        }

        // POST: /VideoSource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Source,URL")] VideoSource videoSource)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoSource).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoSource);
        }

        // GET: /VideoSource/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoSource videoSource = db.VideoSources.Find(id);
            if (videoSource == null)
            {
                return HttpNotFound();
            }
            return View(videoSource);
        }

        // POST: /VideoSource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoSource videoSource = db.VideoSources.Find(id);
            db.VideoSources.Remove(videoSource);
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
