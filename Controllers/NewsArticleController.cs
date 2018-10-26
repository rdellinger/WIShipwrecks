using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;
using PagedList;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class NewsArticleController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /NewsArticle/
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            // If there is a new searchString, start over at page 1
            if (searchString != null)
            {
                page = 1;
            }
            else  // If not, then get the existing searchString
            {
                searchString = currentFilter;
            }

            // Save the current searchString in the ViewBag
            ViewBag.CurrentFilter = searchString;


            // Create a list of NewsArticles to filter against
            var newsarticles = from a in db.NewsArticles
                              select a;

            // If there is a searchString, filter against it
            if (!String.IsNullOrEmpty(searchString))
            {
                newsarticles = newsarticles.Where(s => s.Newspaper.Newspaper1.ToUpper().Contains(searchString.ToUpper())
                                       || s.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Notes.ToUpper().Contains(searchString.ToUpper())
                                       || s.Object.ToUpper().Contains(searchString.ToUpper())
                                       );
            }

            // Return the filtered list
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(newsarticles.OrderBy(s => s.Name).ToPagedList(pageNumber, pageSize));
        }




        // GET: /NewsArticle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsarticle = db.NewsArticles.Find(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            return View(newsarticle);
        }

        // GET: /NewsArticle/Create
        public ActionResult Create()
        {
            ViewBag.NewspaperID = new SelectList(db.Newspapers, "ID", "Newspaper1");
            return View();
        }

        // POST: /NewsArticle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,NewspaperID,Object,Name,Date,Page,Notes,OtherSpelling")] NewsArticle newsarticle)
        {
            if (ModelState.IsValid)
            {
                db.NewsArticles.Add(newsarticle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsarticle);
        }

        // GET: /NewsArticle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsarticle = db.NewsArticles.Find(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }

            ViewBag.NewspaperID = new SelectList(db.Newspapers, "ID", "Newspaper1", newsarticle.NewspaperID);

            return View(newsarticle);
        }

        // POST: /NewsArticle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,NewspaperID,Object,Name,Date,Page,Notes,OtherSpelling")] NewsArticle newsarticle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsarticle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsarticle);
        }

        // GET: /NewsArticle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsArticle newsarticle = db.NewsArticles.Find(id);
            if (newsarticle == null)
            {
                return HttpNotFound();
            }
            return View(newsarticle);
        }

        // POST: /NewsArticle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsArticle newsarticle = db.NewsArticles.Find(id);
            db.NewsArticles.Remove(newsarticle);
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
