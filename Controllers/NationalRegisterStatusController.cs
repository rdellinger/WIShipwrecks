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
    public class NationalRegisterStatusController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /NationalRegisterStatus/
        public ActionResult Index()
        {
            return View(db.NationalRegisterStatus1.ToList());
        }

        // GET: /NationalRegisterStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalRegisterStatus nationalregisterstatus = db.NationalRegisterStatus1.Find(id);
            if (nationalregisterstatus == null)
            {
                return HttpNotFound();
            }
            return View(nationalregisterstatus);
        }

        // GET: /NationalRegisterStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /NationalRegisterStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Status")] NationalRegisterStatus nationalregisterstatus)
        {
            if (ModelState.IsValid)
            {
                db.NationalRegisterStatus1.Add(nationalregisterstatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nationalregisterstatus);
        }

        // GET: /NationalRegisterStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalRegisterStatus nationalregisterstatus = db.NationalRegisterStatus1.Find(id);
            if (nationalregisterstatus == null)
            {
                return HttpNotFound();
            }
            return View(nationalregisterstatus);
        }

        // POST: /NationalRegisterStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Status")] NationalRegisterStatus nationalregisterstatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nationalregisterstatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nationalregisterstatus);
        }

        // GET: /NationalRegisterStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NationalRegisterStatus nationalregisterstatus = db.NationalRegisterStatus1.Find(id);
            if (nationalregisterstatus == null)
            {
                return HttpNotFound();
            }
            return View(nationalregisterstatus);
        }

        // POST: /NationalRegisterStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NationalRegisterStatus nationalregisterstatus = db.NationalRegisterStatus1.Find(id);
            db.NationalRegisterStatus1.Remove(nationalregisterstatus);
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
