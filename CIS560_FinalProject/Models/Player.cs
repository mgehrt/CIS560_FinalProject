using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS560_FinalProject.Models
{
    public class Player
    {
        //PlayerID is automatically setup as PK?
        public int PlayerID { get; set; }

        public int TeamID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Number { get; set; }


    }
}