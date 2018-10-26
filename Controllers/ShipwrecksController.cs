using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class ShipwrecksController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        //
        // GET: /Shipwrecks/
        public ActionResult Index()
        {
            var featuredShipwrecks = from a in db.Vessels
                                     where a.Featured == true
                                     select a;

            ViewBag.FeaturedShipwrecks = featuredShipwrecks.OrderBy(s => s.VesselName);

            return View();
        }
	}
}