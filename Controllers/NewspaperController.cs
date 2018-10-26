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
    public class NewspaperController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /Newspaper/
        public ActionResult Index()
        {
            return View(db.Newspapers.OrderBy(s=> s.Newspaper1).ToList());
        }

        // GET: /Newspaper/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            return View(newspaper);
        }

        // GET: /Newspaper/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Newspaper/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Newspaper1")] Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.Newspapers.Add(newspaper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newspaper);
        }

        // GET: /Newspaper/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            return View(newspaper);
        }

        // POST: /Newspaper/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Newspaper1")] Newspaper newspaper)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newspaper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newspaper);
        }

        // GET: /Newspaper/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newspaper newspaper = db.Newspapers.Find(id);
            if (newspaper == null)
            {
                return HttpNotFound();
            }
            return View(newspaper);
        }

        // POST: /Newspaper/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Newspaper newspaper = db.Newspapers.Find(id);
            db.Newspapers.Remove(newspaper);
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
