using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS560_FinalProject.Controllers
{
    public class PlayerController
    {
        public PlayerContext db = new PlayerContext();
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
        public ActionResult ViewPlayer(int id)
        {
            Player l = db.Players.Where(m => m.PlayerID == id).FirstOrDefault();
            return View(l);
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            Player l = db.Players.Where(m => m.PlayerID == id).FirstOrDefault();
            return View(l);
        }

        [HttpPost]
        public ActionResult EditPlayer(Location l)
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
            Player l = db.Players.Where(m => m.PlayerID == id).FirstOrDefault();
            db.Player.Remove(l);
            db.SaveChanges();
            return RedirectToAction("Index", "Location", null);
        }
    }
}