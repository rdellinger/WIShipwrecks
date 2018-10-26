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
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class GlossaryController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /Glossary/
        public ActionResult Index(string searchString)
        {
            // Create a list of Vessels to filter against
            var terms = from a in db.Glossaries
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                terms = terms.Where(s => s.Term.Contains(searchString));
            }

            // Return the filtered list in alphabetical order
            return View(terms.OrderBy(s => s.Term));
        }




        // GET: /Glossary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glossary glossary = db.Glossaries.Find(id);
            if (glossary == null)
            {
                return HttpNotFound();
            }
            return View(glossary);
        }

        // GET: /Glossary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Glossary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include="ID,Term,Definition")] Glossary glossary)
        {
            if (ModelState.IsValid)
            {
                db.Glossaries.Add(glossary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glossary);
        }

        // GET: /Glossary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glossary glossary = db.Glossaries.Find(id);
            if (glossary == null)
            {
                return HttpNotFound();
            }
            return View(glossary);
        }

        // POST: /Glossary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include="ID,Term,Definition")] Glossary glossary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glossary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glossary);
        }

        // GET: /Glossary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glossary glossary = db.Glossaries.Find(id);
            if (glossary == null)
            {
                return HttpNotFound();
            }
            return View(glossary);
        }

        // POST: /Glossary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glossary glossary = db.Glossaries.Find(id);
            db.Glossaries.Remove(glossary);
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
