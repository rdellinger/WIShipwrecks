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
    public class VesselController : Controller
    {
        private WIShipwrecksEntities db = new WIShipwrecksEntities();

        // GET: /Vessel/
        //[Authorize(Roles = "Administrator")]
        public ActionResult Index(string searchString, string county, string nearestCity)
        {
        
            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(0, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 0));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          select a;

            // If the user is not an Administrator, don't get the hidden records
            if (!User.IsInRole("Administrator") && !User.IsInRole("Shipwrecks Administrator"))
            {
                vessels = vessels.Where(s => s.HideRecord == false);
            }


            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }
           
            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));
            
        }




        // GET: /Attraction/
        //[Authorize(Roles = "Administrator")]
        public ActionResult GoogleFieldTrip()
        {
            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                              select a;

            vessels = vessels.Where(s => s.HideRecord == false && s.HideLocationalInfo == false);

            Response.ContentType = "application/rss+xml";

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }




        // GET: /Vessel/LowerLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult LowerLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(4, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 4));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false && 
                          a.TrailID == 4
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }


        // GET: /Vessel/MidLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult MidLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(5, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 5));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false &&
                          a.TrailID == 5
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }



        // GET: /Vessel/UpperLakeMichigan
        //[Authorize(Roles = "Administrator")]
        public ActionResult UpprLakeMichigan(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(1, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 1));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false &&
                          a.TrailID == 1
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }



        // GET: /Vessel/LakeSuperior
        //[Authorize(Roles = "Administrator")]
        public ActionResult LakeSuperior(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(3, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 3));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false &&
                          a.TrailID == 3
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }



        // GET: /Vessel/InlandWaterways
        //[Authorize(Roles = "Administrator")]
        public ActionResult InlandWaterways(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(2, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 2));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false &&
                          a.TrailID == 2
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }




        // GET: /Vessel/Featured
        //[Authorize(Roles = "Administrator")]
        public ActionResult Featured(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(null, true));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 2));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false &&
                          a.Featured == true
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }



        // GET: /Vessel/SearchResults
        //[Authorize(Roles = "Administrator")]
        public ActionResult SearchResults(string vesselName, int? vesselTypeID, int? casualtyTypeID, int? hullMaterialID, int? propulsionTypeID, int? rigTypeID, int? bodyOfWaterID, int? ownerManagerAgencyID, int? numberOfMasts, string registryNumber, bool? locationKnown)
        {

            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.HideRecord == false
                          select a;

            // Filter by VesselName, if there is any
            if (!String.IsNullOrEmpty(vesselName))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(vesselName));
            }

            // Filter by VesselTypeID, if one has been selected in the dropdown
            if (vesselTypeID != null)
            {
                vessels = vessels.Where(s => s.VesselTypeID == vesselTypeID);
            }

            // Filter by CasualtyTypeID, if one has been selected in the dropdown
            if (casualtyTypeID != null)
            {
                vessels = vessels.Where(s => s.CasualtyTypeID == casualtyTypeID);
            }

            // Filter by HullMaterialID, if one has been selected in the dropdown
            if (hullMaterialID != null)
            {
                vessels = vessels.Where(s => s.HullMaterialID == hullMaterialID);
            }

            // Filter by PropulsionTypeID, if one has been selected in the dropdown
            if (propulsionTypeID != null)
            {
                vessels = vessels.Where(s => s.PropulsionTypeID == propulsionTypeID);
            }

            // Filter by RigTypeID, if one has been selected in the dropdown
            if (rigTypeID != null)
            {
                vessels = vessels.Where(s => s.RigTypeID == rigTypeID);
            }

            // Filter by bodyOfWaterID, if one has been selected in the dropdown
            if (bodyOfWaterID != null)
            {
                vessels = vessels.Where(s => s.BodyOfWaterID == bodyOfWaterID);
            }

            // Filter by ownerManagerAgencyID, if one has been selected in the dropdown
            if (ownerManagerAgencyID != null)
            {
                vessels = vessels.Where(s => s.OwnerManagerAgencyID == ownerManagerAgencyID);
            }

            // Filter by numberOfMasts, if one has been selected in the dropdown
            if (numberOfMasts != null)
            {
                vessels = vessels.Where(s => s.NumberOfMasts == numberOfMasts);
            }

            // Filter by registryNumber, if there is any
            if (!String.IsNullOrEmpty(registryNumber))
            {
                vessels = vessels.Where(s => s.RegistryNumber.Contains(registryNumber));
            }

            // Filter by LocationKnown, if selected
            if (locationKnown != null)
            {
                vessels = vessels.Where(s => s.LocationKnown == locationKnown);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }





        // GET: /Vessel/NoRegion
        //********************************************************************************
        // This is a temporary page used for development.  Delete it after all vessels
        // have been assigned to a region.
        //********************************************************************************
        public ActionResult NoRegion(string searchString, string county, string nearestCity)
        {

            // Create search dropdowns
            // County
            ViewBag.County = new SelectList(ListCounties(2, null));

            // Nearest city   
            ViewBag.NearestCity = new SelectList(ListNearestCities(county, 2));


            // Create a list of Vessels to filter against
            var vessels = from a in db.Vessels
                          where a.TrailID == null
                          select a;

            // Filter by text, if there is any
            if (!String.IsNullOrEmpty(searchString))
            {
                vessels = vessels.Where(s => s.VesselName.Contains(searchString));
            }

            // Filter by County, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(county))
            {
                vessels = vessels.Where(x => x.County == county);
            }

            // Filter by NearestCity, if one has been selected in the dropdown
            if (!String.IsNullOrEmpty(nearestCity))
            {
                vessels = vessels.Where(x => x.NearestCity == nearestCity);
            }

            // Return the filtered list in alphabetical order
            return View(vessels.OrderBy(s => s.VesselName));

        }





        // List Counties
        public List<string> ListCounties(int? trailId, bool? featured){

            var countyList = new List<string>();

            if (trailId != 0 && featured == null){
            var countyQry = from v in db.Vessels
                            where v.County != null &&
                            v.TrailID == trailId
                            orderby v.County
                            select v.County;
                countyList.AddRange(countyQry.Distinct());
            }

            else if (trailId == null && featured != null){
                var countyQry = from v in db.Vessels
                            where v.County != null &&
                            v.Featured == featured
                            orderby v.County
                            select v.County;
                countyList.AddRange(countyQry.Distinct());
            }

            else
            {
                var countyQry = from v in db.Vessels
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

            if (!String.IsNullOrEmpty(county)){
                
                var nearestCityQry = from n in db.Vessels
                                 where n.County == county && n.NearestCity != null
                                 orderby n.NearestCity
                                 select n.NearestCity;

                nearestCityList.AddRange(nearestCityQry.Distinct());
            }

            else
            {
                if (trailId != 0) { 
                    var nearestCityQry = from n in db.Vessels
                                     where n.TrailID == trailId && n.NearestCity != null
                                     orderby n.NearestCity
                                     select n.NearestCity;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }
                else
                {
                    var nearestCityQry = from n in db.Vessels
                                         where n.NearestCity != null
                                         orderby n.NearestCity
                                         select n.NearestCity;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }
                
            }

            return nearestCityList;
            
        }






        // List Nearest Cities using JSON to populate dropdown menu
        public JsonResult ListNearestCitiesJson(string id, int? trailId)
        {
            var nearestCityList = new List<string>();

            if (!String.IsNullOrEmpty(id)) { 
                
                var nearestCityQry = from n in db.Vessels
                                 where n.County == id && n.NearestCity != null
                                 orderby n.NearestCity
                                 select n.NearestCity;

                nearestCityList.AddRange(nearestCityQry.Distinct());
            }

            else
            {
                if (trailId != 0)
                {
                    var nearestCityQry = from n in db.Vessels
                                         where n.TrailID == trailId && n.NearestCity != null
                                         orderby n.NearestCity
                                         select n.NearestCity;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }
                else
                {
                    var nearestCityQry = from n in db.Vessels
                                         where n.NearestCity != null
                                         orderby n.NearestCity
                                         select n.NearestCity;

                    nearestCityList.AddRange(nearestCityQry.Distinct());
                }

            }

            return Json(nearestCityList, JsonRequestBehavior.AllowGet);
            
        }





        // GET: /Vessel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }

            // Get a list of first 10 nearby vessels, don't include the current vessel
            var first10NearbyVessels = (from a in db.Vessels
                                        where a.HideRecord == false && a.HideLocationalInfo == false && a.NearestCity == vessel.NearestCity && a.ID != vessel.ID
                                        select a).OrderBy(s => s.VesselName).Take(10);

            // Get a list of all nearby vessels, don't include the current vessel
            var allNearbyVessels = (from a in db.Vessels
                                    where a.HideRecord == false && a.HideLocationalInfo == false && a.NearestCity == vessel.NearestCity && a.ID != vessel.ID
                                    select a).OrderBy(s => s.VesselName);

            // Get a list of all vessels in the same region (trail), don't include the current vessel
            var allVesselsInRegion = (from a in db.Vessels
                                      where a.HideRecord == false && a.HideLocationalInfo == false && a.TrailID == vessel.TrailID && a.ID != vessel.ID
                                    select a).OrderBy(s => s.VesselName);

            // Get a count of nearby vessels
            ViewBag.nearbyVesselsCount = allNearbyVessels.Count();
            ViewBag.nearbyVesselsCountMinus10 = allNearbyVessels.Count()-10;

            // Add them to the ViewBag
            ViewBag.first10NearbyVessels = first10NearbyVessels;
            ViewBag.allNearbyVessels = allNearbyVessels;
            ViewBag.allVesselsInRegion = allVesselsInRegion;


            // Get a list of nearby attractions
            var attractions = from a in db.Attractions
                              where a.HideRecord == false && a.City == vessel.NearestCity
                              select a;

            ViewBag.nearbyAttractionsCount = attractions.Count();
            ViewBag.nearbyAttractions = attractions.OrderBy(s => s.AttractionName);


            return View(vessel);
        }



        // GET: /Vessel/Create
        //[Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            // Create dropdowns
            ViewBag.VesselTypeID = new SelectList(db.VesselTypes.OrderBy(s => s.VesselType1), "ID", "VesselType1");
            ViewBag.CasualtyTypeID = new SelectList(db.CasualtyTypes.OrderBy(s => s.CasualtyType1), "ID", "CasualtyType1");
            ViewBag.HullMaterialID = new SelectList(db.HullMaterials.OrderBy(s => s.HullMaterial1), "ID", "HullMaterial1");
            ViewBag.PropulsionTypeID = new SelectList(db.PropulsionTypes.OrderBy(s => s.PropulsionType1), "ID", "PropulsionType1");
            ViewBag.RigTypeID = new SelectList(db.RigTypes.OrderBy(s => s.RigType1), "ID", "RigType1");
            ViewBag.BodyOfWaterID = new SelectList(db.BodiesOfWaters.OrderBy(s => s.BodyOfWater), "ID", "BodyOfWater");
            ViewBag.TrailID = new SelectList(db.Trails.OrderBy(s => s.TrailName), "ID", "TrailName");
            ViewBag.OwnerManagerAgencyID = new SelectList(db.OwnerManagerAgencies.OrderBy(s => s.OwnerManagerAgency1), "ID", "OwnerManagerAgency1");
            ViewBag.NationalRegisterStatusID = new SelectList(db.NationalRegisterStatus1.OrderBy(s => s.Status), "ID", "Status");
            ViewBag.PercentVesselPresent = new SelectList(db.PercentVesselPresents.OrderBy(s => s.ID), "ID", "Range");
            ViewBag.SturgeonBayStone = new SelectList(db.SturgeonBayStones.OrderBy(s => s.ID), "ID", "SturgeonBayStone1");
            ViewBag.IDAccuracy = new SelectList(db.IDAccuracies.OrderBy(s => s.ID), "ID", "Accuracy");
            ViewBag.LocationPotential = new SelectList(db.LocationPotentials.OrderBy(s => s.ID), "ID", "LocationPotential1");
            ViewBag.Culture = new SelectList(db.Cultures.OrderBy(s => s.ID), "ID", "Culture1");
            ViewBag.DatingMethods = new SelectList(db.DatingMethods.OrderBy(s => s.ID), "ID", "DatingMethods");

            return View();
        }



        // POST: /Vessel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,VesselTypeID,VesselName,ASINumber,CasualtyTypeID,CasualtyDate,VesselAge,Owners,HomePort,Master,CargoDescription,LivesLost,FormerNames,RegistryNumber,WhereBuilt,Builder,ContructionYear,Length,Breadth,DepthOfHold,GrossTonnage,NetTonnage,OMTonnage,HullMaterialID,PropulsionTypeID,NumberOfMasts,RigTypeID,Engines,Boilers,Culture,CulturalMaterial,DatingMethods,SurveyDate,SurveyPrincipleInvestigator,ExcavatedDate,ExcavationPrincipleInvestigator,NationalRegisterStatusID,NationalRegisterStatusNotes,YearListedNationalRegister,Submerged,WaterDepth,OnShoreline,ConditionDescription,PercentVesselPresent,WreckThreatened,SiteName,IDAccuracy,CodeNumber,BodyOfWaterID,TrailID,County,NearestCity,PACNumber,LocationPotential,DiveAccessible,NOAAChart,TRS,QuarterSections,USGSQuad,OwnerManagerAgencyID,SturgeonBayStone,HasWHSMooringBuoy,MooringBuoyInPlace,HideLocationalInfo,AccessDirections,HasWHSDiveGuide,ChartImageFileName,LocationKnown,Latitude,LatitudeDecimal,Longitude,LongitudeDecimal,Featured,HideRecord,LastModifiedBy,LastModifiedDate")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {

                vessel.LastModifiedBy = User.Identity.Name;
                vessel.LastModifiedDate = DateTime.Now;

                var thisID = db.Vessels.Add(vessel);
                db.SaveChanges();
                return RedirectToAction("Edit", thisID);
            }

            return View(vessel);
        }



        // GET: /Vessel/Edit/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }

            // Create dropdowns
            ViewBag.VesselTypeID = new SelectList(db.VesselTypes.OrderBy(s => s.VesselType1), "ID", "VesselType1", vessel.VesselTypeID);
            ViewBag.CasualtyTypeID = new SelectList(db.CasualtyTypes.OrderBy(s => s.CasualtyType1), "ID", "CasualtyType1", vessel.CasualtyTypeID);
            ViewBag.HullMaterialID = new SelectList(db.HullMaterials.OrderBy(s => s.HullMaterial1), "ID", "HullMaterial1", vessel.HullMaterialID);
            ViewBag.PropulsionTypeID = new SelectList(db.PropulsionTypes.OrderBy(s => s.PropulsionType1), "ID", "PropulsionType1", vessel.PropulsionTypeID);
            ViewBag.RigTypeID = new SelectList(db.RigTypes.OrderBy(s => s.RigType1), "ID", "RigType1", vessel.RigTypeID);
            ViewBag.BodyOfWaterID = new SelectList(db.BodiesOfWaters.OrderBy(s => s.BodyOfWater), "ID", "BodyOfWater", vessel.BodyOfWaterID);
            ViewBag.TrailID = new SelectList(db.Trails.OrderBy(s => s.TrailName), "ID", "TrailName", vessel.TrailID);
            ViewBag.OwnerManagerAgencyID = new SelectList(db.OwnerManagerAgencies.OrderBy(s => s.OwnerManagerAgency1), "ID", "OwnerManagerAgency1", vessel.OwnerManagerAgencyID);
            ViewBag.NationalRegisterStatusID = new SelectList(db.NationalRegisterStatus1.OrderBy(s => s.Status), "ID", "Status", vessel.NationalRegisterStatusID);
            ViewBag.PercentVesselPresent = new SelectList(db.PercentVesselPresents.OrderBy(s => s.ID), "ID", "Range", vessel.PercentVesselPresent);
            ViewBag.SturgeonBayStone = new SelectList(db.SturgeonBayStones.OrderBy(s => s.ID), "ID", "SturgeonBayStone1", vessel.SturgeonBayStone);
            ViewBag.IDAccuracy = new SelectList(db.IDAccuracies.OrderBy(s => s.ID), "ID", "Accuracy", vessel.IDAccuracy);
            ViewBag.LocationPotential = new SelectList(db.LocationPotentials.OrderBy(s => s.ID), "ID", "LocationPotential1", vessel.LocationPotential);
            ViewBag.Culture = new SelectList(db.Cultures.OrderBy(s => s.ID), "ID", "Culture1", vessel.Culture);
            ViewBag.DatingMethods = new SelectList(db.DatingMethods.OrderBy(s => s.ID), "ID", "DatingMethods", vessel.DatingMethods);

            return View(vessel);
        }



        // POST: /Vessel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,VesselTypeID,VesselName,ASINumber,CasualtyTypeID,CasualtyDate,VesselAge,Owners,HomePort,Master,CargoDescription,LivesLost,FormerNames,RegistryNumber,WhereBuilt,Builder,ContructionYear,Length,Breadth,DepthOfHold,GrossTonnage,NetTonnage,OMTonnage,HullMaterialID,PropulsionTypeID,NumberOfMasts,RigTypeID,Engines,Boilers,Culture,CulturalMaterial,DatingMethods,SurveyDate,SurveyPrincipleInvestigator,ExcavatedDate,ExcavationPrincipleInvestigator,NationalRegisterStatusID,NationalRegisterStatusNotes,YearListedNationalRegister,Submerged,WaterDepth,OnShoreline,ConditionDescription,PercentVesselPresent,WreckThreatened,SiteName,IDAccuracy,CodeNumber,BodyOfWaterID,TrailID,County,NearestCity,PACNumber,LocationPotential,DiveAccessible,NOAAChart,TRS,QuarterSections,USGSQuad,OwnerManagerAgencyID,SturgeonBayStone,HasWHSMooringBuoy,MooringBuoyInPlace,HideLocationalInfo,AccessDirections,HasWHSDiveGuide,ChartImageFileName,LocationKnown,Latitude,LatitudeDecimal,Longitude,LongitudeDecimal,Featured,FeaturedPhoto,HideRecord,LastModifiedBy,LastModifiedDate")] Vessel vessel)
        {
            if (ModelState.IsValid)
            {
                vessel.LastModifiedBy = User.Identity.Name;
                vessel.LastModifiedDate = DateTime.Now;

                db.Entry(vessel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vessel);
        }



        // GET: /Vessel/Delete/5
        //[Authorize(Roles = "Administrator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vessel vessel = db.Vessels.Find(id);
            if (vessel == null)
            {
                return HttpNotFound();
            }
            return View(vessel);
        }



        // POST: /Vessel/Delete/5
        //[Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vessel vessel = db.Vessels.Find(id);
            db.Vessels.Remove(vessel);
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
