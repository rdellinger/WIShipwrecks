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
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class AttractionController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();


        // GET: /Attraction/
        //[Authorize(Roles = "Administrator")]
        public ActionResult Index(string searchString, string trail, string county, string nearestCity, string attractionType)
        {

            // Create search dropdowns
            // Tail
            ViewBag.Trail = new SelectList(db.Trails.OrderBy(s => s.TrailName), "TrailName", "TrailName");

            // County
            ViewBag.County = new SelectList(ListCounties(0));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 0));


            // Create a list of Attractions to filter against
            var attractions = from a in db.Attractions
                          select a;

            // If the user is not an Administrator, don't get the hidden records
            if (!User.IsInRole("Administrator") || !User.IsInRole("Shipwrecks Administrator"))
            {
                attractions = attractions.Where(s => s.HideRecord == false);
            }

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by Trail, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(trail))
            {
                attractions = attractions.Where(x => x.Trail.TrailName == trail);
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Filter by AttractionType, if one has been selected
            if (!String.IsNullOrEmpty(attractionType))
            {
                attractions = attractions.Where(x => x.AttractionType.AttractionType1 == attractionType);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }




        // GET: /Attraction/
        //[Authorize(Roles = "Administrator")]
        public ActionResult GoogleFieldTrip()
        {
            // Create a list of Attractions to filter against
            var attractions = from a in db.Attractions
                              select a;

            attractions = attractions.Where(s => s.HideRecord == false);


            Response.ContentType = "application/rss+xml";

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }





        // GET: /Vessel/LowerLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult LowerLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(4));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 4));


            // Create a list of Vessels to filter against
            var attractions = from a in db.Attractions
                          where a.HideRecord == false &&
                          a.TrailID == 4
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }


        // GET: /Vessel/MidLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult MidLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(5));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 5));


            // Create a list of Vessels to filter against
            var attractions = from a in db.Attractions
                              where a.HideRecord == false &&
                              a.TrailID == 5
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }



        // GET: /Vessel/UpperLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult UpprLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(1));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 1));


            // Create a list of Vessels to filter against
            var attractions = from a in db.Attractions
                              where a.HideRecord == false &&
                              a.TrailID == 1
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }



        // GET: /Vessel/LakeSuperior
        //[Authorize(Roles = "Administrator")]
        public ActionResult LakeSuperior(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(3));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 3));


            // Create a list of Vessels to filter against
            var attractions = from a in db.Attractions
                              where a.HideRecord == false &&
                              a.TrailID == 3
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }



        // GET: /Vessel/InlandWaterways
        //[Authorize(Roles = "Administrator")]
        public ActionResult InlandWaterways(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(2));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 2));


            // Create a list of Vessels to filter against
            var attractions = from a in db.Attractions
                              where a.HideRecord == false &&
                              a.TrailID == 2
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                attractions = attractions.Where(s => s.AttractionName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                attractions = attractions.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                attractions = attractions.Where(x => x.City == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }





        // List Counties
        public List<string> ListCounties(int? trailId)
        {

            var countyList = new List<string>();

            if (trailId != 0)
            {
                var countyQry = from v in db.Attractions
                                where v.County != null &&
                                v.TrailID == trailId
                                orderby v.County
                                select v.County;
                countyList.AddRange(countyQry.Distinct());
            }

            else
            {
                var countyQry = from v in db.Attractions
                                where v.County != null
                                orderby v.County
                                select v.County;
                countyList.AddRange(countyQry.Distinct());
            }

            return countyList;
        }






        // List Nearest Cities
        public List<string> ListNearestCities(string county, int? trailId)
        {
            var nearestCityList = new List<string>();

            if (!String.IsNullOrEmpty(county))
            {

                var nearestCityQry = from n in db.Attractions
                                     where n.County == county && n.City != null
                                     orderby n.City
                                     select n.City;

                nearestCityList.AddRange(nearestCityQry.Distinct());
            }

            else
            {
                if (trailId != 0)
                {
                    var nearestCityQry = from n in db.Attractions
                                         where n.TrailID == trailId && n.City != null
                                         orderby n.City
                                         select n.City;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }
                else
                {
                    var nearestCityQry = from n in db.Attractions
                                         where n.City != null
                                         orderby n.City
                                         select n.City;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }

            }

            return nearestCityList;

        }






        // List Nearest Cities using JSON to populate dropdown menu
        public JsonResult ListNearestCitiesJson(string id, int? trailId)
        {
            var nearestCityList = new List<string>();

            if (!String.IsNullOrEmpty(id))
            {

                var nearestCityQry = from n in db.Attractions
                                     where n.County == id && n.City != null
                                     orderby n.City
                                     select n.City;

                nearestCityList.AddRange(nearestCityQry.Distinct());
            }

            else
            {
                if (trailId != 0)
                {
                    var nearestCityQry = from n in db.Attractions
                                         where n.TrailID == trailId && n.City != null
                                         orderby n.City
                                         select n.City;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }
                else
                {
                    var nearestCityQry = from n in db.Attractions
                                         where n.City != null
                                         orderby n.City
                                         select n.City;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }

            }

            return Json(nearestCityList, JsonRequestBehavior.AllowGet);

        }




        // GET: /Vessel/LowerLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult ByAttractionType(string attractionType)
        {

            // Create a list of Attractions to filter against
            var attractions = from a in db.Attractions
                              where a.HideRecord == false
                              select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(attractionType))
            {
                attractions = attractions.Where(s => s.AttractionType.AttractionType1.Contains(attractionType));
            }


            // Return the filtered list in alphabetical order
            return View(attractions.OrderBy(s => s.AttractionName));

        }





        // GET: /Vessel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }


            // Get a list of first 10 nearby vessels, don't include the current vessel
            var first10NearbyVessels = (from a in db.Vessels
                                        where a.HideRecord == false && a.NearestCity == attraction.City
                                        select a).OrderBy(s => s.VesselName).Take(10);

            // Get a list of all nearby vessels, don't include the current vessel
            var allNearbyVessels = (from a in db.Vessels
                                    where a.HideRecord == false && a.NearestCity == attraction.City
                                    select a).OrderBy(s => s.VesselName);

            // Get a list of all vessels in the same region (trail), don't include the current attraction
            var allVesselsInRegion = (from a in db.Vessels
                                      where a.HideRecord == false && a.TrailID == attraction.TrailID && a.ID != attraction.ID
                                      select a).OrderBy(s => s.VesselName);

            // Get a count of nearby vessels
            ViewBag.nearbyVesselsCount = allNearbyVessels.Count();
            ViewBag.nearbyVesselsCountMinus10 = allNearbyVessels.Count() - 10;

            // Add them to the ViewBag
            ViewBag.first10NearbyVessels = first10NearbyVessels;
            ViewBag.allNearbyVessels = allNearbyVessels;
            ViewBag.allVesselsInRegion = allVesselsInRegion;


            // Get a list of nearby attractions
            var attractions = from a in db.Attractions
                              where a.HideRecord == false && a.City == attraction.City
                              select a;

            var allAttractionsInRegion = from a in db.Attractions
                                         where a.HideRecord == false && a.TrailID == attraction.TrailID && a.ID != attraction.ID
                                         select a;

            ViewBag.nearbyAttractionsCount = attractions.Count();
            ViewBag.nearbyAttractions = attractions.OrderBy(s => s.AttractionName);
            ViewBag.allAttractionsInRegion = allAttractionsInRegion;


            // Get a list of attraction contacts
            var attractionContacts = from a in db.AttractionContacts
                                     where a.AttractionID == id
                                     select a;

            ViewBag.attractionContactsCount = attractionContacts.Count();
            ViewBag.attractionContacts = attractionContacts.OrderBy(s => s.ContactName);

            // Get a list of attraction links
            var attractionLinks = from a in db.AttractionLinks
                                     where a.AttractionID == id
                                     select a;

            ViewBag.attractionLinksCount = attractionLinks.Count();
            ViewBag.attractionLinks = attractionLinks.OrderBy(s => s.Title);


            return View(attraction);
        }


        // GET: /Attraction/Create
        //[Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            ViewBag.AttractionTypeID = new SelectList(db.AttractionTypes.OrderBy(s => s.AttractionType1), "ID", "AttractionType1");
            ViewBag.BodyOfWaterID = new SelectList(db.BodiesOfWaters.OrderBy(s => s.BodyOfWater), "ID", "BodyOfWater");
            ViewBag.TrailID = new SelectList(db.Trails.OrderBy(s => s.TrailName), "ID", "TrailName");

            return View();
        }

        // POST: /Attraction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AttractionName,AttractionTypeID,BodyOfWaterID,TrailID,YearBuilt,Description,NearestAddress,City,County,ZipCode,OpenToPublic,HasWHSMooringBuoy,MooringBuoyInPlace,IsSnorkelable,HasWHSDiveGuide,HasTrailsSign,HasTrailsExhibit,IsNationalRegisterListed,Latitude,LatitudeDecimal,Longitude,LongitudeDecimal,HideRecord,LastModifiedBy,LastModifiedDate")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                
                attraction.LastModifiedBy = User.Identity.Name;
                attraction.LastModifiedDate = DateTime.Now;

                var thisID = db.Attractions.Add(attraction);
                db.SaveChanges();
                return RedirectToAction("Edit", thisID);
            }

            return View(attraction);
        }

        // GET: /Attraction/Edit/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }

            ViewBag.AttractionTypeID = new SelectList(db.AttractionTypes.OrderBy(s => s.AttractionType1), "ID", "AttractionType1", attraction.AttractionTypeID);
            ViewBag.BodyOfWaterID = new SelectList(db.BodiesOfWaters.OrderBy(s => s.BodyOfWater), "ID", "BodyOfWater", attraction.BodyOfWaterID);
            ViewBag.TrailID = new SelectList(db.Trails.OrderBy(s => s.TrailName), "ID", "TrailName", attraction.TrailID);

            return View(attraction);
        }



        // POST: /Attraction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AttractionName,AttractionTypeID,BodyOfWaterID,TrailID,YearBuilt,Description,NearestAddress,City,County,ZipCode,OpenToPublic,HasWHSMooringBuoy,MooringBuoyInPlace,IsSnorkelable,HasWHSDiveGuide,HasTrailsSign,HasTrailsExhibit,IsNationalRegisterListed,Latitude,LatitudeDecimal,Longitude,LongitudeDecimal,HideRecord,LastModifiedBy,LastModifiedDate")] Attraction attraction)
        {
            if (ModelState.IsValid)
            {
                attraction.LastModifiedBy = User.Identity.Name;
                attraction.LastModifiedDate = DateTime.Now;

                db.Entry(attraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(attraction);
        }



        // GET: /Attraction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attraction attraction = db.Attractions.Find(id);
            if (attraction == null)
            {
                return HttpNotFound();
            }
            return View(attraction);
        }



        // POST: /Attraction/Delete/5
        //[Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attraction attraction = db.Attractions.Find(id);
            db.Attractions.Remove(attraction);
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
