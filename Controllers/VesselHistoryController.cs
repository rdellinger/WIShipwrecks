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
    public class VesselHistoryController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VesselHistory/
        public ActionResult Index()
        {
            var vesselhistories = db.VesselHistories.Include(v => v.Vessel).Include(v => v.TimeFrame1);
            return View(vesselhistories.ToList());
        }

        // GET: /VesselHistory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselHistory vesselhistory = db.VesselHistories.Find(id);
            if (vesselhistory == null)
            {
                return HttpNotFound();
            }
            return View(vesselhistory);
        }

        // GET: /VesselHistory/Create
        public ActionResult Create(int? vesselId)
        {
            // Save the VesselID to the ViewBag so you can redirect back
            Vessel vessel = db.Vessels.Find(vesselId);
            ViewBag.VesselID = vessel.ID;

            ViewBag.TimeFrame = new SelectList(db.TimeFrames, "ID", "TimeFrame1");
            return View();
        }

        // POST: /VesselHistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="ID,VesselID,TimeFrame,Title,Subtitle,Description")] VesselHistory vesselhistory)
        {
            var redirectURL = "../Vessel/Edit/" + vesselhistory.VesselID + "#story";

            // If the page is reloaded with an error message from below, the vesselId is lost in the querystring
            // so save the VesselID in the ViewBag to use in those cases
            ViewBag.VesselID = vesselhistory.VesselID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.TimeFrame = new SelectList(db.TimeFrames.OrderBy(s => s.DisplayOrder), "ID", "TimeFrame1");


            if (ModelState.IsValid)
            {
                db.VesselHistories.Add(vesselhistory);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            ViewBag.VesselID = new SelectList(db.Vessels, "ID", "VesselName", vesselhistory.VesselID);
            ViewBag.TimeFrame = new SelectList(db.TimeFrames, "ID", "TimeFrame1", vesselhistory.TimeFrame);
            //return View(vesselhistory);
            return Redirect(redirectURL);
        }



        // GET: /VesselHistory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselHistory vesselhistory = db.VesselHistories.Find(id);
            if (vesselhistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.TimeFrame = new SelectList(db.TimeFrames, "ID", "TimeFrame1", vesselhistory.TimeFrame);
            return View(vesselhistory);
        }

        // POST: /VesselHistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="ID,VesselID,TimeFrame,Title,Subtitle,Description")] VesselHistory vesselhistory)
        {
            var redirectURL = "../../Vessel/Edit/" + vesselhistory.VesselID + "#story";

            if (ModelState.IsValid)
            {
                db.Entry(vesselhistory).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }
            
            ViewBag.TimeFrame = new SelectList(db.TimeFrames, "ID", "TimeFrame1", vesselhistory.TimeFrame);
            //return View(vesselhistory);
            return Redirect(redirectURL);
        }



        // GET: /VesselHistory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselHistory vesselhistory = db.VesselHistories.Find(id);
            if (vesselhistory == null)
            {
                return HttpNotFound();
            }
            return View(vesselhistory);
        }



        // POST: /VesselHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VesselHistory vesselhistory = db.VesselHistories.Find(id);
            var vesselId = vesselhistory.VesselID;

            db.VesselHistories.Remove(vesselhistory);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Vessel/Edit/" + vesselId + "#story";
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
