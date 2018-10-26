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
    public class SturgeonBayStoneController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /SturgeonBayStone/
        public ActionResult Index()
        {
            return View(db.SturgeonBayStones.OrderBy(s=> s.SturgeonBayStone1).ToList());
        }

        // GET: /SturgeonBayStone/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SturgeonBayStone sturgeonbaystone = db.SturgeonBayStones.Find(id);
            if (sturgeonbaystone == null)
            {
                return HttpNotFound();
            }
            return View(sturgeonbaystone);
        }

        // GET: /SturgeonBayStone/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SturgeonBayStone/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,SturgeonBayStone1")] SturgeonBayStone sturgeonbaystone)
        {
            if (ModelState.IsValid)
            {
                db.SturgeonBayStones.Add(sturgeonbaystone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sturgeonbaystone);
        }

        // GET: /SturgeonBayStone/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SturgeonBayStone sturgeonbaystone = db.SturgeonBayStones.Find(id);
            if (sturgeonbaystone == null)
            {
                return HttpNotFound();
            }
            return View(sturgeonbaystone);
        }

        // POST: /SturgeonBayStone/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,SturgeonBayStone1")] SturgeonBayStone sturgeonbaystone)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sturgeonbaystone).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sturgeonbaystone);
        }

        // GET: /SturgeonBayStone/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SturgeonBayStone sturgeonbaystone = db.SturgeonBayStones.Find(id);
            if (sturgeonbaystone == null)
            {
                return HttpNotFound();
            }
            return View(sturgeonbaystone);
        }

        // POST: /SturgeonBayStone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SturgeonBayStone sturgeonbaystone = db.SturgeonBayStones.Find(id);
            db.SturgeonBayStones.Remove(sturgeonbaystone);
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
