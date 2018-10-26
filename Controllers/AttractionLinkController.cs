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
    public class AttractionLinkController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /AttractionLink/
        public ActionResult Index()
        {
            var attractionlinks = db.AttractionLinks.Include(a => a.Attraction);
            return View(attractionlinks.ToList());
        }



        // GET: /AttractionLink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionLink attractionlink = db.AttractionLinks.Find(id);
            if (attractionlink == null)
            {
                return HttpNotFound();
            }
            return View(attractionlink);
        }



        // GET: /AttractionLink/Create
        public ActionResult Create()
        {
            return View();
        }




        // POST: /AttractionLink/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,AttractionID,Title,Link")] AttractionLink attractionlink)
        {
            var redirectURL = "../Attraction/Edit/" + attractionlink.AttractionID + "#links";

            if (ModelState.IsValid)
            {
                db.AttractionLinks.Add(attractionlink);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            //return View(attractionlink);
            return Redirect(redirectURL);
        }




        // GET: /AttractionLink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionLink attractionlink = db.AttractionLinks.Find(id);
            if (attractionlink == null)
            {
                return HttpNotFound();
            }
            ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractionlink.AttractionID);
            return View(attractionlink);
        }

        // POST: /AttractionLink/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AttractionID,Title,Link")] AttractionLink attractionlink)
        {
            var redirectURL = "../../Attraction/Edit/" + attractionlink.AttractionID + "#links";

            if (ModelState.IsValid)
            {
                db.Entry(attractionlink).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }
            //ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractionlink.AttractionID);
            //return View(attractionlink);
            return Redirect(redirectURL);
        }



        // GET: /AttractionLink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionLink attractionlink = db.AttractionLinks.Find(id);
            if (attractionlink == null)
            {
                return HttpNotFound();
            }
            return View(attractionlink);
        }

        // POST: /AttractionLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttractionLink attractionlink = db.AttractionLinks.Find(id);
            db.AttractionLinks.Remove(attractionlink);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Attraction/Edit/" + attractionlink.AttractionID + "#links";
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
