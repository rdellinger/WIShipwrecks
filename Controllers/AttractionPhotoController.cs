using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class AttractionPhotoController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /AttractionPhoto/
        public ActionResult Index()
        {
            var attractionphotos = db.AttractionPhotos.Include(a => a.Attraction);
            return View(attractionphotos.ToList());
        }

        // GET: /AttractionPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionPhoto attractionphoto = db.AttractionPhotos.Find(id);
            if (attractionphoto == null)
            {
                return HttpNotFound();
            }
            return View(attractionphoto);
        }


        // GET: /AttractionPhoto/DetailsForGallery/5
        public ActionResult DetailsForGallery(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionPhoto attractionphoto = db.AttractionPhotos.Find(id);
            if (attractionphoto == null)
            {
                return HttpNotFound();
            }
            return View(attractionphoto);
        }



        // GET: /AttractionPhoto/Create
        public ActionResult Create(int? attractionId)
        {
            // Save the AttractionID to the ViewBag so you can redirect back
            Attraction attraction = db.Attractions.Find(attractionId);
            ViewBag.AttractionID = attraction.ID;

            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1");
            return View();
        }



        // POST: /AttractionPhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AttractionID,Image,Thumb,Caption,PhotoSourceID,PhotoTypeID,DateOfPhoto")] AttractionPhoto attractionphoto, HttpPostedFileBase file)
        {
            var redirectURL = "../Attraction/Edit/" + attractionphoto.AttractionID + "#images";
            
            // If the page is reloaded with an error message from below, the attractionId is lost in the querystring
            // so save the AttractionID in the ViewBag to use in those cases
            ViewBag.AttractionID = attractionphoto.AttractionID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1");

            // if file's content length is zero or no files submitted
            if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("uploadError", "File's length is zero, or no files found");
                return View(attractionphoto);
            }

            // check the file size (max 4 Mb)
            if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
            {
                ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                return View(attractionphoto);
            }

            // check the file size (min 100 bytes)
            //if (Request.Files[0].ContentLength < 100)
            //{
            //    ModelState.AddModelError("uploadError", "File size is too small");
            //    return View(attractionphoto);
            //}

            // check file extension
            string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
            {
                ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                return View(attractionphoto);
            }

            // extract only the filename
            var fileName = Path.GetFileName(file.FileName);

            // store the file inside ~/Images/Attractions folder
            var path = Path.Combine(Server.MapPath("~/Images/Attractions"), fileName);

            try
            {
                if (!System.IO.File.Exists(path))
                {
                    Request.Files[0].SaveAs(path);
                    //System.IO.File.Delete(path);
                }
                else
                {
                    ModelState.AddModelError("uploadError", "An image with that name already exists.  Please rename your image.");
                    return View(attractionphoto);
                }
                
            }
            catch (Exception)
            {
                ModelState.AddModelError("uploadError", "Can't save file to disk");
            }

            

            if (ModelState.IsValid)
            {
                attractionphoto.Image = file.FileName;

                db.AttractionPhotos.Add(attractionphoto);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            //ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractionphoto.AttractionID);
            //return View(attractionphoto);
            return Redirect(redirectURL);

        }



        // GET: /AttractionPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionPhoto attractionphoto = db.AttractionPhotos.Find(id);
            if (attractionphoto == null)
            {
                return HttpNotFound();
            }

            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source", attractionphoto.PhotoSourceID);
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1", attractionphoto.PhotoTypeID);
            
            return View(attractionphoto);
        }



        // POST: /AttractionPhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AttractionID,Image,Thumb,Caption,PhotoSourceID,PhotoTypeID,DateOfPhoto")] AttractionPhoto attractionphoto)
        {
            var redirectURL = "../../Attraction/Edit/" + attractionphoto.AttractionID + "#images";

            if (ModelState.IsValid)
            {
                db.Entry(attractionphoto).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }
            //ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractionphoto.AttractionID);
            //return View(attractionphoto);
            return Redirect(redirectURL);
        }



        // GET: /AttractionPhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttractionPhoto attractionphoto = db.AttractionPhotos.Find(id);
            if (attractionphoto == null)
            {
                return HttpNotFound();
            }
            return View(attractionphoto);
        }




        // POST: /AttractionPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AttractionPhoto attractionphoto = db.AttractionPhotos.Find(id);

            // get the filename
            var fileName = Path.GetFileName(attractionphoto.Image);

            // get the path to the file
            var path = Path.Combine(Server.MapPath("~/Images/Attractions"), fileName);

            // delete the file
            try
            {
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);
            }
            catch (Exception)
            {
                ModelState.AddModelError("uploadError", "Can't delete the file.");
            }

            
            db.AttractionPhotos.Remove(attractionphoto);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Attraction/Edit/" + attractionphoto.AttractionID + "#images";
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
