using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS560_FinalProject.EF;
using System.Data.Entity;
using CIS560_FinalProject.Models;

namespace CIS560_FinalProject.Controllers
{
    public class LocationController : Controller
    {


        //public ActionResult Index()
        //{
        //    TournamentDbHandle tdb = new TournamentDbHandle();

        //    return View(tdb.GetTournaments());

        //}



        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLocation(Location l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LocationDbHandler ldb = new LocationDbHandler();
                    if (ldb.AddLocation(l))
                    {
                        ViewBag.Message = "Location Created Correctly";
                        ModelState.Clear();
                    }
                }
                return RedirectToAction("Index", "Home", null);
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ViewLocation(int id)
        {
            LocationDbHandler ldb = new LocationDbHandler();
            ViewBag.LocationID = id;
            return View(ldb.ViewLocation(id));
        }

        [HttpGet]
        public ActionResult EditLocation(int id)
        {
            LocationDbHandler ldb = new LocationDbHandler();
            return View(ldb.GetLocations().Find(m => m.LocationID == id));
        }

        [HttpPost]
        public ActionResult EditLocation(Location l)
        {
            if (ModelState.IsValid)
            {
                LocationDbHandler ldb = new LocationDbHandler();
                ldb.updateLocation(l);
                return RedirectToAction("Index");
            }
            return View(l);
        }

        public ActionResult DeleteLocation(int id)
        {
            LocationDbHandler ldb = new LocationDbHandler();
            if (ldb.DeleteLocation(id))
            {
                return RedirectToAction("Index", "Home", null);
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}