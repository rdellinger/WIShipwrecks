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
    public class FeedbackRecipientController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /FeedbackRecipient/
        public ActionResult Index()
        {
            return View(db.FeedbackRecipients.ToList());
        }

        // GET: /FeedbackRecipient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackRecipient feedbackRecipient = db.FeedbackRecipients.Find(id);
            if (feedbackRecipient == null)
            {
                return HttpNotFound();
            }
            return View(feedbackRecipient);
        }

        // GET: /FeedbackRecipient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /FeedbackRecipient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Email")] FeedbackRecipient feedbackRecipient)
        {
            if (ModelState.IsValid)
            {
                db.FeedbackRecipients.Add(feedbackRecipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(feedbackRecipient);
        }

        // GET: /FeedbackRecipient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackRecipient feedbackRecipient = db.FeedbackRecipients.Find(id);
            if (feedbackRecipient == null)
            {
                return HttpNotFound();
            }
            return View(feedbackRecipient);
        }

        // POST: /FeedbackRecipient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Email")] FeedbackRecipient feedbackRecipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedbackRecipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(feedbackRecipient);
        }

        // GET: /FeedbackRecipient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FeedbackRecipient feedbackRecipient = db.FeedbackRecipients.Find(id);
            if (feedbackRecipient == null)
            {
                return HttpNotFound();
            }
            return View(feedbackRecipient);
        }

        // POST: /FeedbackRecipient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FeedbackRecipient feedbackRecipient = db.FeedbackRecipients.Find(id);
            db.FeedbackRecipients.Remove(feedbackRecipient);
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
