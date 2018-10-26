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
    public class MapController : Controller
    {

        private WIShipwrecksEntities db = new WIShipwrecksEntities();


        // GET: /Map/
        public ActionResult Index()
        {
            return View();
        }



        // GET: /Map/Featured
        public ActionResult All()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "";
            ViewBag.Zoom = 7;
            ViewBag.CenterOnLat = 45.190082;
            ViewBag.CenterOnLong = -90.089539;
            ViewBag.ControllerName = "Index";

            return View("Map");
        }
        
        

        // GET: /Map/Featured
        public ActionResult Featured()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.Featured == true
                                    select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Featured";
            ViewBag.Zoom = 7;
            ViewBag.CenterOnLat = 45.190082;
            ViewBag.CenterOnLong = -90.089539;
            ViewBag.ControllerName = "Featured";

            return View("Map");
        }



        // GET: /Map/LowerLakeMichigan
        public ActionResult LowerLakeMichigan()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.TrailID == 4
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Lower Lake Michigan";
            ViewBag.Zoom = 9;
            ViewBag.CenterOnLat = 43.036776;
            ViewBag.CenterOnLong = -87.902435;
            ViewBag.ControllerName = "LowerLakeMichigan";

            return View("Map");
        }



        // GET: /Map/MidLakeMichigan
        public ActionResult MidLakeMichigan()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.TrailID == 5
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Mid Lake Michigan";
            ViewBag.Zoom = 9;
            ViewBag.CenterOnLat = 43.448931;
            ViewBag.CenterOnLong = -87.863983;
            ViewBag.ControllerName = "MidLakeMichigan";

            return View("Map");
        }



        // GET: /Map/UpprLakeMichigan
        public ActionResult UpprLakeMichigan()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.TrailID == 1
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Upper Lake Michigan";
            ViewBag.Zoom = 9;
            ViewBag.CenterOnLat = 44.837369;
            ViewBag.CenterOnLong = -87.359264;
            ViewBag.ControllerName = "UpprLakeMichigan";

            return View("Map");
        }



        // GET: /Map/LakeSuperior
        public ActionResult LakeSuperior()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.TrailID == 3
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Lake Superior";
            ViewBag.Zoom = 10;
            ViewBag.CenterOnLat = 46.888355;
            ViewBag.CenterOnLong = -91.184189;
            ViewBag.ControllerName = "LakeSuperior";

            return View("Map");
        }



        // GET: /Map/InlandWaterways
        public ActionResult InlandWaterways()
        {
            // Get a list of all nearby vessels, don't include the current vessel
            var allVessels = (from a in db.Vessels
                              where a.HideRecord == false && a.HideLocationalInfo == false && a.LatitudeDecimal != null && a.LongitudeDecimal != null && a.TrailID == 2
                              select a);

            // Add them to the ViewBag
            ViewBag.AllVessels = allVessels;
            ViewBag.AllVesselsCount = allVessels.Count();

            // Set the map settings
            ViewBag.Title = "Inland Waterways";
            ViewBag.Zoom = 9;
            ViewBag.CenterOnLat = 44.837369;
            ViewBag.CenterOnLong = -87.359264;
            ViewBag.ControllerName = "InlandWaterways";

            return View("Map");
        }



	}
}