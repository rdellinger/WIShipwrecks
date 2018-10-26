using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WIShipwrecks.Models;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class LearnController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        //
        // GET: /Learn/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchingForShipwrecks()
        {
            return View();
        }

        public ActionResult DocumentingShipwrecks()
        {
            return View();
        }

        public ActionResult WorkingUnderwater()
        {
            return View();
        }

        public ActionResult ShipwreckConservation()
        {
            return View();
        }

        
        
        public ActionResult CurrentResearch()
        {
            // Create a list of Current Research
            var currentResearch = from a in db.CurrentResearches
                          select a;

            ViewBag.CurrentResearch = currentResearch.OrderBy(s => s.DisplayOrder);

            return View();
        }



        public ActionResult TechnicalFieldReports()
        {
            // Create a list of Technical Field Reports
            var technicalFieldReports = from a in db.TechnicalFieldReports
                                  select a;

            ViewBag.TechnicalFieldReports = technicalFieldReports.OrderBy(s => s.DisplayOrder);

            return View();
        }


        public ActionResult Calendar()
        {
            // Create a list of Calendar events
            var calendar = from a in db.Calendars
                                  select a;

            ViewBag.Calendar = calendar.OrderBy(s => s.Date);
            ViewBag.CalendarCount = calendar.Count();

            return View();
        }


        public ActionResult ExploringShipwrecks()
        {
            return View();
        }

        public ActionResult ShipwrecksEverywhere()
        {
            return View();
        }

        public ActionResult LighthousesAndLifesaving()
        {
            return View();
        }

        public ActionResult DeathsDoor()
        {
            return View();
        }

        public ActionResult InfoForDivers()
        {
            return View();
        }

        public ActionResult Glossary()
        {
            return View();
        }

        public ActionResult LinksToOtherSites()
        {
            // Create a list of Links
            var links = from a in db.Links
                                  select a;

            ViewBag.Links = links.OrderBy(s => s.Title);

            return View();
        }

        public ActionResult DiveGuides()
        {
            return View();
        }

	}
}