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
        public TournamentContext db = new TournamentContext();
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLocation(Location l)
        {
            db.Locations.Add(l);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewLocation(int id)
        {
            Location l = db.Locations.Where(m => m.LocationID == id).FirstOrDefault();
            return View(l);
        }

        [HttpGet]
        public ActionResult EditLocation(int id)
        {
            Location l = db.Locations.Where(m => m.LocationID == id).FirstOrDefault();
            return View(l);
        }

        [HttpPost]
        public ActionResult EditLocation(Location l)
        {
            if (ModelState.IsValid)
            {
                db.Entry(l).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(l);
        }

        public ActionResult DeleteLocation(int id)
        {
            Location l = db.Locations.Where(m => m.LocationID == id).FirstOrDefault();
            db.Locations.Remove(l);
            db.SaveChanges();
            return RedirectToAction("Index", "Location", null);
        }
    }
}
