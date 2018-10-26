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
    public class CasualtyTypeController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /CasualtyType/
        public ActionResult Index()
        {
            return View(db.CasualtyTypes.ToList());
        }

        // GET: /CasualtyType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasualtyType casualtytype = db.CasualtyTypes.Find(id);
            if (casualtytype == null)
            {
                return HttpNotFound();
            }
            return View(casualtytype);
        }

        // GET: /CasualtyType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CasualtyType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,CasualtyType1")] CasualtyType casualtytype)
        {
            if (ModelState.IsValid)
            {
                db.CasualtyTypes.Add(casualtytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(casualtytype);
        }

        // GET: /CasualtyType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasualtyType casualtytype = db.CasualtyTypes.Find(id);
            if (casualtytype == null)
            {
                return HttpNotFound();
            }
            return View(casualtytype);
        }

        // POST: /CasualtyType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,CasualtyType1")] CasualtyType casualtytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(casualtytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(casualtytype);
        }

        // GET: /CasualtyType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CasualtyType casualtytype = db.CasualtyTypes.Find(id);
            if (casualtytype == null)
            {
                return HttpNotFound();
            }
            return View(casualtytype);
        }

        // POST: /CasualtyType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CasualtyType casualtytype = db.CasualtyTypes.Find(id);
            db.CasualtyTypes.Remove(casualtytype);
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
