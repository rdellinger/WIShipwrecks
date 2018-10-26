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
    public class VesselPhotoController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /VesselPhoto/
        public ActionResult Index()
        {
            var vesselphotos = db.VesselPhotos.Include(v => v.PhotoSource).Include(v => v.PhotoType).Include(v => v.Vessel);
            return View(vesselphotos.ToList());
        }

        // GET: /VesselPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselPhoto vesselphoto = db.VesselPhotos.Find(id);
            if (vesselphoto == null)
            {
                return HttpNotFound();
            }
            return View(vesselphoto);
        }


        // GET: /VesselPhoto/DetailsForGallery/5
        public ActionResult DetailsForGallery(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselPhoto vesselphoto = db.VesselPhotos.Find(id);
            if (vesselphoto == null)
            {
                return HttpNotFound();
            }
            return View(vesselphoto);
        }



        // GET: /VesselPhoto/Create
        public ActionResult Create(int? vesselId)
        {
            // Save the VesselID to the ViewBag so you can redirect back
            Vessel vessel = db.Vessels.Find(vesselId);
            ViewBag.VesselID = vessel.ID;

            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1");
            return View();
        }




        // POST: /VesselPhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,VesselID,Image,Thumb,Caption,PhotoSourceID,PhotoTypeID,DateOfPhoto")] VesselPhoto vesselphoto, HttpPostedFileBase file)
        {
            var redirectURL = "../Vessel/Edit/" + vesselphoto.VesselID + "#images";

            // If the page is reloaded with an error message from below, the VesselID is lost in the querystring
            // so save the VesselID in the ViewBag to use in those cases
            ViewBag.VesselID = vesselphoto.VesselID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1");

            // if file's content length is zero or no files submitted
            if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
            {
                ModelState.AddModelError("uploadError", "Please select an image to upload.");
                return View(vesselphoto);
            }

            // check the file size (max 4 Mb)
            if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
            {
                ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                return View(vesselphoto);
            }

            // check file extension
            string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

            if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
            {
                ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                return View(vesselphoto);
            }

            // extract only the filename
            var fileName = Path.GetFileName(file.FileName);

            // store the file inside ~/Images folder
            var path = Path.Combine(Server.MapPath("~/Images"), fileName);

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
                    return View(vesselphoto);
                }

            }
            catch (Exception)
            {
                ModelState.AddModelError("uploadError", "Can't save file to disk");
            }



            if (ModelState.IsValid)
            {
                vesselphoto.Image = file.FileName;

                db.VesselPhotos.Add(vesselphoto);
                db.SaveChanges();
                //return RedirectToAction("Index");
                return Redirect(redirectURL);
            }

            //ViewBag.AttractionID = new SelectList(db.Attractions, "ID", "AttractionName", attractionphoto.AttractionID);
            //return View(attractionphoto);
            return Redirect(redirectURL);
        }




        // GET: /VesselPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselPhoto vesselphoto = db.VesselPhotos.Find(id);
            if (vesselphoto == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source", vesselphoto.PhotoSourceID);
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1", vesselphoto.PhotoTypeID);

            // Set this to false by default
            ViewBag.ShowImageExistsError = false;

            return View(vesselphoto);
        }





        // POST: /VesselPhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VesselID,Image,Thumb,Caption,PhotoSourceID,PhotoTypeID,DateOfPhoto")] VesselPhoto vesselphoto, HttpPostedFileBase file)
        {
            var redirectURL = "../../Vessel/Edit/" + vesselphoto.VesselID + "#images";

            // If the page is reloaded with an error message from below, the VesselID is lost in the querystring
            // so save the VesselID in the ViewBag to use in those cases
            ViewBag.VesselID = vesselphoto.VesselID;

            // The ViewBag with the dropdown lists must also be recreated
            ViewBag.PhotoSourceID = new SelectList(db.PhotoSources.OrderBy(s => s.Source), "ID", "Source");
            ViewBag.PhotoTypeID = new SelectList(db.PhotoTypes.OrderBy(s => s.PhotoType1), "ID", "PhotoType1");

            // If a new image is being uploaded, run validation and upload it
            if (file != null)
            {
                // if file's content length is zero or no files submitted and there is no existing photo
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select an image to upload.");
                    return View(vesselphoto);
                }

                // check the file size (max 4 Mb)
                if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                    return View(vesselphoto);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
                {
                    ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                    return View(vesselphoto);
                }

                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);

                // store the file inside ~/Images folder
                var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                var oldImagePath = Path.Combine(Server.MapPath("~/Images"), vesselphoto.Image);

                try
                {
                    if (!System.IO.File.Exists(path))
                    {
                        // Save the new image
                        Request.Files[0].SaveAs(path);

                        // Delete the old image
                        System.IO.File.Delete(oldImagePath);
                    }
                    else
                    {
                        ModelState.AddModelError("uploadError", "An image with that name already exists.  Please rename your image.");
                        return View(vesselphoto);
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
                    vesselphoto.Image = file.FileName;
                }
                else
                {
                    vesselphoto.Image = vesselphoto.Image;
                }

                db.Entry(vesselphoto).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect(redirectURL);
            }

            return Redirect(redirectURL);
        }




        // GET: /VesselPhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VesselPhoto vesselphoto = db.VesselPhotos.Find(id);
            if (vesselphoto == null)
            {
                return HttpNotFound();
            }
            return View(vesselphoto);
        }



        // POST: /VesselPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VesselPhoto vesselphoto = db.VesselPhotos.Find(id);

            // get the filename
            var fileName = Path.GetFileName(vesselphoto.Image);

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


            db.VesselPhotos.Remove(vesselphoto);
            db.SaveChanges();
            //return RedirectToAction("Index");
            var redirectURL = "../../Vessel/Edit/" + vesselphoto.VesselID + "#images";
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
