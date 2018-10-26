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
    public class AttractionTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /AttractionType/
        public ActionResult Index()
        {
            return View(db.AttractionTypes.OrderBy(s=> s.DisplayOrder).ToList());
        }

        // GET: /AttractionType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionType attractiontype = db.AttractionTypes.Find(id);
            if (attractiontype == null)
            {
                return HttpNotFound();
            }
            return View(attractiontype);
        }

        // GET: /AttractionType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /AttractionType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,AttractionType1,DisplayOrder")] AttractionType attractiontype)
        {
            if (ModelState.IsValid)
            {
                db.AttractionTypes.Add(attractiontype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attractiontype);
        }

        // GET: /AttractionType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionType attractiontype = db.AttractionTypes.Find(id);
            if (attractiontype == null)
            {
                return HttpNotFound();
            }
            return View(attractiontype);
        }

        // POST: /AttractionType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,AttractionType1,DisplayOrder")] AttractionType attractiontype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attractiontype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attractiontype);
        }

        // GET: /AttractionType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionType attractiontype = db.AttractionTypes.Find(id);
            if (attractiontype == null)
            {
                return HttpNotFound();
            }
            return View(attractiontype);
        }

        // POST: /AttractionType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttractionType attractiontype = db.AttractionTypes.Find(id);
            db.AttractionTypes.Remove(attractiontype);
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
