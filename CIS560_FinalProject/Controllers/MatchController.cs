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
    public class MatchController : Controller
    {
        public TournamentContext db = new TournamentContext();
        // GET: Match
        public ActionResult Index(int id)
        {
            //needs to get replaced with sql
            var matchup = db.Matches.Where(m => m.MatchID == id).FirstOrDefault();
            return View("ViewMatch", matchup);
        }
        
        [HttpGet]
        public ActionResult CreateMatch(int TournamentID)
        {
            ViewBag.TournamentID = TournamentID;
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateMatch(Match m)
        {
            if (ModelState.IsValid)
            {
                MatchDbHandler mdb = new MatchDbHandler();
                if (mdb.AddMatch(m))
                {
                    return RedirectToAction("Index", "Match", null);
                }
            }
            return View("Index");
        }

        // GET: Match/Edit/5
        public ActionResult EditMatch(int id)
        {
            Match m = db.Matches.Where(t => t.MatchID == id).FirstOrDefault();
            return View(m);
        }

        // POST: Match/Edit/5
        [HttpPost]
        public ActionResult EditMatch(Match m)
        {
            if (ModelState.IsValid)
            {
                db.Entry(m).State = EntityState.Modified;
                db.SaveChanges();
                RedirectToAction("Index");
            }
            return View(m);
        }

        // POST: Match/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Match m = db.Matches.Where(t => t.MatchID == id).FirstOrDefault();
            db.Matches.Remove(m);
            db.SaveChanges();
            return RedirectToAction("Index", "Match", null);
        }
    }
}
