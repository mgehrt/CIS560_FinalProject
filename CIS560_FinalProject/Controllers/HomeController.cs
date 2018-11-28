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
    public class HomeController : Controller
    {
        public TournamentContext db = new TournamentContext();

        public ActionResult Index()
        {
            var list = db.Tournaments.ToList();
            
            return View(list);

        }

        

        [HttpGet]
        public ActionResult CreateTournament()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTournament(Tournament t)
        {
            db.Tournaments.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult ViewTournament(int id)
        {
          //  var list = db.Tournaments.SqlQuery(,)
            Tournament t = db.Tournaments.Where(m => m.TournamentID == id).FirstOrDefault();
            return View(t);
        }

        [HttpGet]
        public ActionResult EditTournament(int id)
        {
            Tournament t = db.Tournaments.Where(m => m.TournamentID == id).FirstOrDefault();
            return View(t);
        }

        [HttpPost]
        public ActionResult EditTournament(Tournament t)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t).State= EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t);
        }

        public ActionResult DeleteTournament(int id)
        {
            Tournament t = db.Tournaments.Where(m => m.TournamentID == id).FirstOrDefault();
            db.Tournaments.Remove(t);
            db.SaveChanges();
            return RedirectToAction("Index", "Home", null);
        }
    }
}