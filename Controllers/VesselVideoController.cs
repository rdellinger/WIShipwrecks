using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class VesselVideoController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VesselVideo/
        public ActionResult Index()
        {
            var vesselvideos = db.VesselVideos.Include(v => v.Vessel).Include(v => v.VideoSource).Include(v => v.VideoType);
            return View(vesselvideos.ToList());
        }

        // GET: /VesselVideo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselVideo vesselVideo = db.VesselVideos.Find(id);
            if (vesselVideo == null)
            {
                return HttpNotFound();
            }
            return View(vesselVideo);
        }

        // GET: /VesselVideo/DetailsForGallery/5
        public ActionResult DetailsForGallery(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselVideo vesselVideo = db.VesselVideos.Find(id);
            if (vesselVideo == null)
            {
                return HttpNotFound();
            }
            return View(vesselVideo);
        }


        // GET: /VesselVideo/Create
        public ActionResult Create(int? vesselId)
        {
            // Save the VesselID to the ViewBag so you can redirect back
            Vessel vessel = db.Vessels.Find(vesselId);
            ViewBag.VesselID = vessel.ID;

            ViewBag.VideoSourceID = new SelectList(db.VideoSources, "ID", "Source");
            ViewBag.VideoTypeID = new SelectList(db.VideoTypes, "ID", "VideoType1");
            return View();
        }

        // POST: /VesselVideo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VesselID,YouTubeCode,Thumb,Caption,VideoSourceID,VideoTypeID,DateOfVideo")] VesselVideo vesselVideo, HttpPostedFileBase file)
        {
            var redirectURL = "../Vessel/Edit/" + vesselVideo.VesselID + "#videos";

            // If the page is reloaded with an error message from below, the vesselId is lost in the querystring
            // so save the VesselID in the ViewBag to use in those cases
            ViewBag.VesselID = vesselVideo.VesselID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.VideoSourceID = new SelectList(db.VideoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.VideoTypeID = new SelectList(db.VideoTypes.OrderBy(s => s.VideoType1), "ID", "VideoType1");

            // if file's content length is zero or no files submitted
            if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("uploadError", "Please select a thumbnail image to upload.");
                return View(vesselVideo);
            }

            // check the file size (max 4 Mb)
            if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
            {
                ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                return View(vesselVideo);
            }

            // check file extension
            string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
            {
                ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                return View(vesselVideo);
            }

            // extract only the filename and rename it with thumb_ prefix
            var fileName = "thumb_" + Path.GetFileName(file.FileName);
            
            // get the path where it should be saved
            var path = Path.Combine(Server.MapPath("~/Images"), fileName);

            try
            {
                if (!System.IO.File.Exists(path))
                {
                    // upload the image
                    Request.Files[0].SaveAs(path);
                    
                    // resize the image
                    var thisThumb = new WebImage(path).Resize(500, 500, true).Crop(1, 1);  // Cropping it to remove 1px border at top and left sides (bug in WebImage)
                    thisThumb.Save(path);
                }
                else
                {
                    ModelState.AddModelError("uploadError", "An image with that name already exists.  Please rename your image.");
                    return View(vesselVideo);
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("uploadError", "Can't save file to disk");
            }



            if (ModelState.IsValid)
            {
                vesselVideo.Thumb = "thumb_" + file.FileName;

                db.VesselVideos.Add(vesselVideo);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            //return View
            return Redirect(redirectURL);
        }




        // GET: /VesselVideo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselVideo vesselVideo = db.VesselVideos.Find(id);
            if (vesselVideo == null)
            {
                return HttpNotFound();
            }
            ViewBag.VesselID = new SelectList(db.Vessels, "ID", "VesselName", vesselVideo.VesselID);
            ViewBag.VideoSourceID = new SelectList(db.VideoSources, "ID", "Source", vesselVideo.VideoSourceID);
            ViewBag.VideoTypeID = new SelectList(db.VideoTypes, "ID", "VideoType1", vesselVideo.VideoTypeID);
            return View(vesselVideo);
        }


        // POST: /VesselVideo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VesselID,YouTubeCode,Thumb,Caption,VideoSourceID,VideoTypeID,DateOfVideo")] VesselVideo vesselVideo, HttpPostedFileBase file)
        {
            var redirectURL = "../../Vessel/Edit/" + vesselVideo.VesselID + "#videos";

            // If the page is reloaded with an error message from below, the vesselId is lost in the querystring
            // so save the VesselID in the ViewBag to use in those cases
            ViewBag.VesselID = vesselVideo.VesselID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.VideoSourceID = new SelectList(db.VideoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.VideoTypeID = new SelectList(db.VideoTypes.OrderBy(s => s.VideoType1), "ID", "VideoType1");

            // If a new image is being uploaded, run validation and upload it
            if (file != null)
            {
                // if file's content length is zero or no files submitted
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select a thumbnail image to upload.");
                    return View(vesselVideo);
                }

                // check the file size (max 4 Mb)
                if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                    return View(vesselVideo);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
                {
                    ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                    return View(vesselVideo);
                }

                // extract only the filename and rename it with thumb_ prefix
                var fileName = "thumb_" + Path.GetFileName(file.FileName);
                var oldImageFileName = Path.GetFileName(vesselVideo.Thumb);

                // get the path where it should be saved
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                var oldImagePath = Path.Combine(Server.MapPath("~/Images"), oldImageFileName);

                try
                {
                    if (!System.IO.File.Exists(path))
                    {
                        // upload the image
                        Request.Files[0].SaveAs(path);

                        // resize the image
                        var thisThumb = new WebImage(path).Resize(500, 500, true).Crop(1, 1);  // Cropping it to remove 1px border at top and left sides (bug in WebImage)
                        thisThumb.Save(path);

                        // Delete the old image
                        System.IO.File.Delete(oldImagePath);

                    }
                    else
                    {
                        ModelState.AddModelError("uploadError", "An image with that name already exists.  Please rename your image.");
                        return View(vesselVideo);
                    }

                }
                catch (Exception)
                {
                    ModelState.AddModelError("uploadError", "Can't save file to disk");
                }
            
            }
            

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var fileName = "thumb_" + Path.GetFileName(file.FileName);
                    vesselVideo.Thumb = fileName;
                }
                else
                {
                    var oldImageFileName = Path.GetFileName(vesselVideo.Thumb);
                    vesselVideo.Thumb = oldImageFileName;
                }

                db.Entry(vesselVideo).State = EntityState.Modified;
                db.SaveChanges();
 
                return Redirect(redirectURL);
            }

            return Redirect(redirectURL);
        }



        // GET: /VesselVideo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselVideo vesselVideo = db.VesselVideos.Find(id);
            if (vesselVideo == null)
            {
                return HttpNotFound();
            }
            return View(vesselVideo);
        }




        // POST: /VesselVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VesselVideo vesselVideo = db.VesselVideos.Find(id);

            // get the filename
            var fileName = Path.GetFileName(vesselVideo.Thumb);

            // get the path to the file
            var path = Path.Combine(Server.MapPath("~/Images"), fileName);

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


            db.VesselVideos.Remove(vesselVideo);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Vessel/Edit/" + vesselVideo.VesselID + "#videos";
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
