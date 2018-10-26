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
    public class TimeFrameController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /TimeFrame/
        public ActionResult Index()
        {
            return View(db.TimeFrames.ToList());
        }

        // GET: /TimeFrame/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeFrame timeframe = db.TimeFrames.Find(id);
            if (timeframe == null)
            {
                return HttpNotFound();
            }
            return View(timeframe);
        }

        // GET: /TimeFrame/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TimeFrame/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,TimeFrame1,DisplayOrder")] TimeFrame timeframe)
        {
            if (ModelState.IsValid)
            {
                db.TimeFrames.Add(timeframe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeframe);
        }

        // GET: /TimeFrame/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeFrame timeframe = db.TimeFrames.Find(id);
            if (timeframe == null)
            {
                return HttpNotFound();
            }
            return View(timeframe);
        }

        // POST: /TimeFrame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,TimeFrame1,DisplayOrder")] TimeFrame timeframe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeframe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeframe);
        }

        // GET: /TimeFrame/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeFrame timeframe = db.TimeFrames.Find(id);
            if (timeframe == null)
            {
                return HttpNotFound();
            }
            return View(timeframe);
        }

        // POST: /TimeFrame/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeFrame timeframe = db.TimeFrames.Find(id);
            db.TimeFrames.Remove(timeframe);
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
