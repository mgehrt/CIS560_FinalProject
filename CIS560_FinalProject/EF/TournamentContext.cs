using CIS560_FinalProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace CIS560_FinalProject.EF
{
    public class TournamentContext : DbContext
    {
        public TournamentContext() : base("TournamentContext")
        {
            //we don't necessarily need anything here
        }

        


        //Foreach of our classes we need a DbSet of type ClassName named the plural version of the class
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
}