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
        

        public ActionResult Index()
        {
            TournamentDbHandle tdb = new TournamentDbHandle();
            
            return View(tdb.GetTournaments());

        }

        

        [HttpGet]
        public ActionResult CreateTournament()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTournament(Tournament t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TournamentDbHandle tdb = new TournamentDbHandle();
                    if (tdb.AddTournament(t))
                    {
                        ViewBag.Message = "Tournament Created Correctly";
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
        public ActionResult CreateTeam()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ViewTournament(int id)
        {
            TournamentDbHandle tdb = new TournamentDbHandle();
            ViewBag.TournamentID = id;
            return View(tdb.ViewTournament(id));
        }

        [HttpGet]
        public ActionResult EditTournament(int id)
        {
            TournamentDbHandle tdb = new TournamentDbHandle();
            return View(tdb.GetTournaments().Find(m => m.TournamentID == id));
        }

        [HttpPost]
        public ActionResult EditTournament(Tournament t)
        {
            if (ModelState.IsValid)
            {
                TournamentDbHandle tdb = new TournamentDbHandle();
                tdb.UpdateTournament(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }

        public ActionResult DeleteTournament(int id)
        {
            TournamentDbHandle tdb = new TournamentDbHandle();
            if (tdb.DeleteTournament(id))
            {
                return RedirectToAction("Index", "Home", null);
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}