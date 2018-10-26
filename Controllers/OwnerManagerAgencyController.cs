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
    public class OwnerManagerAgencyController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /OwnerManagerAgency/
        public ActionResult Index()
        {
            return View(db.OwnerManagerAgencies.OrderBy(s=> s.OwnerManagerAgency1).ToList());
        }

        // GET: /OwnerManagerAgency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerManagerAgency ownermanageragency = db.OwnerManagerAgencies.Find(id);
            if (ownermanageragency == null)
            {
                return HttpNotFound();
            }
            return View(ownermanageragency);
        }

        // GET: /OwnerManagerAgency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /OwnerManagerAgency/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,OwnerManagerAgency1,Address,Phone")] OwnerManagerAgency ownermanageragency)
        {
            if (ModelState.IsValid)
            {
                db.OwnerManagerAgencies.Add(ownermanageragency);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ownermanageragency);
        }

        // GET: /OwnerManagerAgency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerManagerAgency ownermanageragency = db.OwnerManagerAgencies.Find(id);
            if (ownermanageragency == null)
            {
                return HttpNotFound();
            }
            return View(ownermanageragency);
        }

        // POST: /OwnerManagerAgency/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,OwnerManagerAgency1,Address,Phone")] OwnerManagerAgency ownermanageragency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ownermanageragency).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ownermanageragency);
        }

        // GET: /OwnerManagerAgency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OwnerManagerAgency ownermanageragency = db.OwnerManagerAgencies.Find(id);
            if (ownermanageragency == null)
            {
                return HttpNotFound();
            }
            return View(ownermanageragency);
        }

        // POST: /OwnerManagerAgency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OwnerManagerAgency ownermanageragency = db.OwnerManagerAgencies.Find(id);
            db.OwnerManagerAgencies.Remove(ownermanageragency);
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
