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
    }
}