using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WIShipwrecks.Controllers
{
    //[Authorize(Roles = "Administrator, Shipwrecks Administrator, Shipwrecks Editor")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}