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
    public class CurrentResearchController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /CurrentResearch/
        public ActionResult Index()
        {
            return View(db.CurrentResearches.ToList().OrderBy(s=> s.DisplayOrder));
        }



        // GET: /CurrentResearch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentResearch currentResearch = db.CurrentResearches.Find(id);
            if (currentResearch == null)
            {
                return HttpNotFound();
            }
            return View(currentResearch);
        }



        // GET: /CurrentResearch/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: /CurrentResearch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Image,DisplayOrder")] CurrentResearch currentResearch, HttpPostedFileBase file)
        {
            if (file != null)
            { 
                // if file's content length is zero or no files submitted
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select an image to upload.");
                    return View(currentResearch);
                }

                // check the file size (max 4 Mb)
                if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                    return View(currentResearch);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
                {
                    ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                    return View(currentResearch);
                }

                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);

                // store the file inside ~/Images folder
                var path = Path.Combine(Server.MapPath("~/Images/CurrentResearch"), fileName);

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
                        return View(currentResearch);
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
                    currentResearch.Image = file.FileName;
                }
                else
                {
                    currentResearch.Image = null;
                }


                db.CurrentResearches.Add(currentResearch);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(currentResearch);

        }





        // GET: /CurrentResearch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentResearch currentResearch = db.CurrentResearches.Find(id);
            if (currentResearch == null)
            {
                return HttpNotFound();
            }
            return View(currentResearch);
        }



        // POST: /CurrentResearch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Description,Image,DisplayOrder")] CurrentResearch currentResearch, HttpPostedFileBase file)
        {
            // If a new image is being uploaded, run validation and upload it
            if (file != null)
            {
                // if file's content length is zero or no files submitted and there is no existing photo
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select an image to upload.");
                    return View(currentResearch);
                }

                // check the file size (max 4 Mb)
                if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
                    return View(currentResearch);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".jpg" && extension != ".jpeg" && extension != ".gif" && extension != ".png")
                {
                    ModelState.AddModelError("uploadError", "Supported file extensions: jpg, jpeg, gif, png");
                    return View(currentResearch);
                }

                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);

                // store the file inside ~/Images folder
                var path = Path.Combine(Server.MapPath("~/Images/CurrentResearch"), fileName);

                try
                {
                    if (!System.IO.File.Exists(path))
                    {
                        // Save the new image
                        Request.Files[0].SaveAs(path);

                        // Delete the old image, if one exists
                        if (currentResearch.Image != null) {
                            var oldImagePath = Path.Combine(Server.MapPath("~/Images/CurrentResearch"), currentResearch.Image);
                            System.IO.File.Delete(oldImagePath);
                        }
                        
                    }
                    else
                    {
                        ModelState.AddModelError("uploadError", "An image with that name already exists.  Please rename your image.");
                        return View(currentResearch);
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
                    currentResearch.Image = file.FileName;
                }
                else
                {
                    currentResearch.Image = currentResearch.Image;
                }

                db.Entry(currentResearch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currentResearch);

        }



        // GET: /CurrentResearch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrentResearch currentResearch = db.CurrentResearches.Find(id);
            if (currentResearch == null)
            {
                return HttpNotFound();
            }
            return View(currentResearch);
        }



        // POST: /CurrentResearch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrentResearch currentResearch = db.CurrentResearches.Find(id);

            // get the filename, if one exists
            if(currentResearch.Image != null){

                var fileName = Path.GetFileName(currentResearch.Image);

                // get the path to the file
                var path = Path.Combine(Server.MapPath("~/Images/CurrentResearch"), fileName);

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

            }
          
            db.CurrentResearches.Remove(currentResearch);
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
