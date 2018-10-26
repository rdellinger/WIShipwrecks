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
    public class DatingMethodController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /DatingMethod/
        public ActionResult Index()
        {
            return View(db.DatingMethods.ToList());
        }

        // GET: /DatingMethod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatingMethod datingmethod = db.DatingMethods.Find(id);
            if (datingmethod == null)
            {
                return HttpNotFound();
            }
            return View(datingmethod);
        }

        // GET: /DatingMethod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /DatingMethod/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,DatingMethods")] DatingMethod datingmethod)
        {
            if (ModelState.IsValid)
            {
                db.DatingMethods.Add(datingmethod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datingmethod);
        }

        // GET: /DatingMethod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatingMethod datingmethod = db.DatingMethods.Find(id);
            if (datingmethod == null)
            {
                return HttpNotFound();
            }
            return View(datingmethod);
        }

        // POST: /DatingMethod/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,DatingMethods")] DatingMethod datingmethod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datingmethod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(datingmethod);
        }

        // GET: /DatingMethod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatingMethod datingmethod = db.DatingMethods.Find(id);
            if (datingmethod == null)
            {
                return HttpNotFound();
            }
            return View(datingmethod);
        }

        // POST: /DatingMethod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatingMethod datingmethod = db.DatingMethods.Find(id);
            db.DatingMethods.Remove(datingmethod);
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
