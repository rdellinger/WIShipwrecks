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
    public class SearchController : Controller
    {

        private WIShipwrecksEntities db = new WIShipwrecksEntities();


        //
        // GET: /Search/
        public ActionResult Index()
        {
            // Create dropdowns
            ViewBag.VesselTypeID = new SelectList(db.VesselTypes.OrderBy(s => s.VesselType1), "ID", "VesselType1");
            ViewBag.CasualtyTypeID = new SelectList(db.CasualtyTypes.OrderBy(s => s.CasualtyType1), "ID", "CasualtyType1");
            ViewBag.HullMaterialID = new SelectList(db.HullMaterials.OrderBy(s => s.HullMaterial1), "ID", "HullMaterial1");
            ViewBag.PropulsionTypeID = new SelectList(db.PropulsionTypes.OrderBy(s => s.PropulsionType1), "ID", "PropulsionType1");
            ViewBag.RigTypeID = new SelectList(db.RigTypes.OrderBy(s => s.RigType1), "ID", "RigType1");
            ViewBag.BodyOfWaterID = new SelectList(db.BodiesOfWaters.OrderBy(s => s.BodyOfWater), "ID", "BodyOfWater");
            ViewBag.OwnerManagerAgencyID = new SelectList(db.OwnerManagerAgencies.OrderBy(s => s.OwnerManagerAgency1), "ID", "OwnerManagerAgency1");
          
            return View();
        }
    }
}