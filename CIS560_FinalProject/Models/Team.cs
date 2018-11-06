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

        public String Name { get; set; }

        public String Mascot { get; set; }
    }
}