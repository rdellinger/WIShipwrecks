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
    public class TechnicalFieldReportsController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /TechnicalFieldReports/
        public ActionResult Index()
        {
            return View(db.TechnicalFieldReports.ToList());
        }

        // GET: /TechnicalFieldReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFieldReport technicalFieldReport = db.TechnicalFieldReports.Find(id);
            if (technicalFieldReport == null)
            {
                return HttpNotFound();
            }
            return View(technicalFieldReport);
        }

        // GET: /TechnicalFieldReports/Create
        public ActionResult Create()
        {
            return View();
        }




        // POST: /TechnicalFieldReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Filename,DisplayOrder")] TechnicalFieldReport technicalFieldReport, HttpPostedFileBase file)
        {
            if (file != null)
            {
                // if file's content length is zero or no files submitted
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select a file to upload.");
                    return View(technicalFieldReport);
                }

                // check the file size (max 4 Mb)
                //if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                // check the file size (max 20 Mb)
                if (Request.Files[0].ContentLength > 5120 * 5120 * 20)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 20 MB");
                    return View(technicalFieldReport);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".pdf")
                {
                    ModelState.AddModelError("uploadError", "Please select a PDF to upload.");
                    return View(technicalFieldReport);
                }

                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);

                // store the file inside ~/Images folder
                var path = Path.Combine(Server.MapPath("~/Files"), fileName);

                try
                {
                    if (!System.IO.File.Exists(path))
                    {
                        Request.Files[0].SaveAs(path);
                        //System.IO.File.Delete(path);
                    }
                    else
                    {
                        ModelState.AddModelError("uploadError", "An file with that name already exists.  Please rename your file.");
                        return View(technicalFieldReport);
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
                    technicalFieldReport.Filename = file.FileName;
                }
                else
                {
                    technicalFieldReport.Filename = null;
                }


                db.TechnicalFieldReports.Add(technicalFieldReport);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(technicalFieldReport);

        }





        // GET: /TechnicalFieldReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFieldReport technicalFieldReport = db.TechnicalFieldReports.Find(id);
            if (technicalFieldReport == null)
            {
                return HttpNotFound();
            }
            return View(technicalFieldReport);
        }




        // POST: /TechnicalFieldReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Filename,DisplayOrder")] TechnicalFieldReport technicalFieldReport, HttpPostedFileBase file)
        {
            // If a new image is being uploaded, run validation and upload it
            if (file != null)
            {
                // if file's content length is zero or no files submitted and there is no existing photo
                if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
                {
                    ModelState.AddModelError("uploadError", "Please select a file to upload.");
                    return View(technicalFieldReport);
                }

                // check the file size (max 4 Mb)
                //if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
                // check the file size (max 20 Mb)
                if (Request.Files[0].ContentLength > 5120 * 5120 * 20)
                {
                    ModelState.AddModelError("uploadError", "File size can't exceed 20 MB");
                    return View(technicalFieldReport);
                }

                // check file extension
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();

                if (extension != ".pdf")
                {
                    ModelState.AddModelError("uploadError", "Please select a PDF to upload.");
                    return View(technicalFieldReport);
                }

                // extract only the filename
                var fileName = Path.GetFileName(file.FileName);

                // store the file inside ~/Images folder
                var path = Path.Combine(Server.MapPath("~/Files"), fileName);

                try
                {
                    if (!System.IO.File.Exists(path))
                    {
                        // Save the new image
                        Request.Files[0].SaveAs(path);

                        // Delete the old image, if one exists
                        if (technicalFieldReport.Filename != null)
                        {
                            var oldFilePath = Path.Combine(Server.MapPath("~/Files"), technicalFieldReport.Filename);
                            System.IO.File.Delete(oldFilePath);
                        }

                    }
                    else
                    {
                        ModelState.AddModelError("uploadError", "An file with that name already exists.  Please rename your file.");
                        return View(technicalFieldReport);
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
                    technicalFieldReport.Filename = file.FileName;
                }
                else
                {
                    technicalFieldReport.Filename = technicalFieldReport.Filename;
                }

                db.Entry(technicalFieldReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(technicalFieldReport);

        }





        // GET: /TechnicalFieldReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TechnicalFieldReport technicalFieldReport = db.TechnicalFieldReports.Find(id);
            if (technicalFieldReport == null)
            {
                return HttpNotFound();
            }
            return View(technicalFieldReport);
        }



        // POST: /TechnicalFieldReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TechnicalFieldReport technicalFieldReport = db.TechnicalFieldReports.Find(id);

            // get the filename, if one exists
            if (technicalFieldReport.Filename != null)
            {

                var fileName = Path.GetFileName(technicalFieldReport.Filename);

                // get the path to the file
                var path = Path.Combine(Server.MapPath("~/Files"), fileName);

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

            db.TechnicalFieldReports.Remove(technicalFieldReport);
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
