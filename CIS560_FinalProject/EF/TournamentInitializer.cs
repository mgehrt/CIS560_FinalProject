using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CIS560_FinalProject.Models;

namespace CIS560_FinalProject.EF
{
    //Contains Seed data to initially populate the database (mainly for testing and presenting)
    public class TournamentInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<TournamentContext>
    {
        protected override void Seed(TournamentContext context)
        {
            var tournaments = new List<Tournament>
            {
                new Tournament{},
                new Tournament{},
                new Tournament{},
                new Tournament{},
                new Tournament{}
            };

            tournaments.ForEach(s => context.Tournaments.Add(s));
            context.SaveChanges();
        }
    }
}