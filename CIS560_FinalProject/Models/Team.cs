using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS560_FinalProject.Models
{
    public class Team
    {
        public int TeamID { get; set; }


        public int LocationID { get; set; }

        public string Name { get; set; }

        public string Mascot { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual Location Location { get; set; }

        public Team (int TeamID, int LocationID, string Name, string Mascot, Location Location)
        {
            this.TeamID = TeamID;
            this.LocationID = LocationID;
            this.Name = Name;
            this.Mascot = Mascot;
            this.Location = Location;
        }
    }
}