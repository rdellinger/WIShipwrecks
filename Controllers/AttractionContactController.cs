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
    public class AttractionContactController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /AttractionContact/
        public ActionResult Index()
        {
            var attractioncontacts = db.AttractionContacts.Include(a => a.Attraction);
            return View(attractioncontacts.ToList());
        }

        // GET: /AttractionContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionContact attractioncontact = db.AttractionContacts.Find(id);
            if (attractioncontact == null)
            {
                return HttpNotFound();
            }
            return View(attractioncontact);
        }

        // GET: /AttractionContact/Create
        public ActionResult Create()
        {
            ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName");
            return View();
        }

        // POST: /AttractionContact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AttractionID,ContactName,ContactPhone,ContactPhoneAlt,Email,Website")] AttractionContact attractioncontact)
        {
            var redirectURL = "../Attraction/Edit/" + attractioncontact.AttractionID + "#contacts";

            if (ModelState.IsValid)
            {
                db.AttractionContacts.Add(attractioncontact);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            //return View(attractioncontact);
            return Redirect(redirectURL);
        }



        // GET: /AttractionContact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionContact attractioncontact = db.AttractionContacts.Find(id);
            if (attractioncontact == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractioncontact.AttractionID);
            return View(attractioncontact);
        }

        // POST: /AttractionContact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AttractionID,ContactName,ContactPhone,ContactPhoneAlt,Email,Website")] AttractionContact attractioncontact)
        {

            var redirectURL = "../../Attraction/Edit/" + attractioncontact.AttractionID + "#contacts";

            if (ModelState.IsValid)
            {
                db.Entry(attractioncontact).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }
            //ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractioncontact.AttractionID);
            //return View(attractioncontact);
            return Redirect(redirectURL);
        }

        // GET: /AttractionContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionContact attractioncontact = db.AttractionContacts.Find(id);
            if (attractioncontact == null)
            {
                return HttpNotFound();
            }
            return View(attractioncontact);
        }

        // POST: /AttractionContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttractionContact attractioncontact = db.AttractionContacts.Find(id);
            db.AttractionContacts.Remove(attractioncontact);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Attraction/Edit/" + attractioncontact.AttractionID + "#contacts";
            return Redirect(redirectURL);
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
