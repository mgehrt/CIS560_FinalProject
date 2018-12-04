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
    public class PlayerController : Controller
    {
        [HttpGet]
        public ActionResult CreatePlayer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePlayer(Player P)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    PlayerDbHandler pdb = new PlayerDbHandler();
                    if (pdb.AddPlayer(P))
                    {
                        ViewBag.Message = "Player Created Correctly";
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
        public ActionResult ViewPlayer(int id)
        {
            PlayerDbHandler pdb = new PlayerDbHandler();
            ViewBag.PlayerID = id;
            return View(pdb.ViewPlayer(id));
        }

        [HttpGet]
        public ActionResult EditPlayer(int id)
        {
            PlayerDbHandler pdb = new PlayerDbHandler();
            return View(pdb.GetPlayers().Find(m => m.PlayerID == id));
        }

        [HttpPost]
        public ActionResult EditPlayer(Player P)
        {
            if (ModelState.IsValid)
            {
                PlayerDbHandler pdb = new PlayerDbHandler();
                pdb.updatePlayer(P);
                return RedirectToAction("Index");
            }
            return View(P);
        }

        public ActionResult DeleteLocation(int id)
        {
            PlayerDbHandler pdb = new PlayerDbHandler();
            if (pdb.DeletPlayer(id))
            {
                return RedirectToAction("Index", "Home", null);
            }
            return RedirectToAction("Index", "Home", null);
        }
    }
}