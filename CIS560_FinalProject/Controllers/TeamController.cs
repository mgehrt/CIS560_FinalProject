using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS560_FinalProject.EF;
using System.Data.Entity;
using CIS560_FinalProject.Models;
using System.Data.SqlClient;

namespace CIS560_FinalProject.Controllers
{
    public class TeamController : Controller
    {
        public TournamentContext db = new TournamentContext();

        // GET: Team
        public ActionResult Index()
        {
            TeamDbHandler tdb = new TeamDbHandler();
            return View(tdb.GetTeams());
        }

        public ActionResult CreateTeam()
        {
            return View();
        }

        public ActionResult ViewTeam(int id)
        {
            TeamDbHandler tbd = new TeamDbHandler();
            return View(tbd.ViewTeam(id));
        }

    }
}