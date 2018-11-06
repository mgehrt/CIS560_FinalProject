using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CIS560_FinalProject.Models
{
    public class Tournament
    {
        //TournamentID is automatically setup as PK
        public int TournamentID { get; set; }

        public string Sport { get; set; }

        public string Name { get; set; }

        //DataType.Date changes the Start and End Dates from DateTime to just calendar date (then updated with the display line)
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; }

        //Currently has an error because Match hasn't been created yet
        public virtual ICollection<Match> Matches { get; set; }
    }
}