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
            TournamentDbHandler tdb = new TournamentDbHandler();
            
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
                    TournamentDbHandler tdb = new TournamentDbHandler();
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
        public ActionResult ViewTeams()
        {
            return RedirectToAction("Index", "Team", null);
        }

        [HttpGet]
        public ActionResult ViewPlayers()
        {
            return RedirectToAction("ViewAllPlayers", "Player", null);
        }

        [HttpGet]
        public ActionResult ViewTournament(int id)
        {
            TeamDbHandler teamdb = new TeamDbHandler();
            List<Team> teams = teamdb.GetTeams();
            TournamentDbHandler tdb = new TournamentDbHandler();
            ViewBag.TournamentID = id;
            List<Match> matches = tdb.ViewTournament(id);
            foreach(Match m in matches)
            {
                foreach(Team t in teams)
                {
                    if(m.Team1ID == t.TeamID)
                    {
                        m.Team1 = t;
                    }
                    else if(m.Team2ID == t.TeamID)
                    {
                        m.Team2 = t;
                    }
                }
            }
            return View(matches);
        }

        [HttpGet]
        public ActionResult EditTournament(int id)
        {
            TournamentDbHandler tdb = new TournamentDbHandler();
            return View(tdb.GetTournaments().Find(m => m.TournamentID == id));
        }

        [HttpPost]
        public ActionResult SearchPlayer(string text)
        {
            PlayerDbHandler pdb = new PlayerDbHandler();
            int id = pdb.SearchPlayer(text);
            return RedirectToAction("ViewPlayer", "Player", new { id});
        }


        [HttpPost]
        public ActionResult EditTournament(Tournament t)
        {
            if (ModelState.IsValid)
            {
                TournamentDbHandler tdb = new TournamentDbHandler();
                tdb.UpdateTournament(t);
                return RedirectToAction("Index");
            }
            return View(t);
        }

        public ActionResult DeleteTournament(int id)
        {
            TournamentDbHandler tdb = new TournamentDbHandler();
            if (tdb.DeleteTournament(id))
            {
                return RedirectToAction("Index", "Home", null);
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}