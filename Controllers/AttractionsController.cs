using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class AttractionsController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        //
        // GET: /Attractions/
        public ActionResult Index()
        {
            var attractionTypes = from a in db.AttractionTypes
                              select a;

            ViewBag.AttractionTypes = attractionTypes.OrderBy(s => s.DisplayOrder);

            return View();
        }
	}
}