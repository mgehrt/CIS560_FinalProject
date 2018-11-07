using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CIS560_FinalProject.Models
{
    public class Match
    {
        //MatchID is automatically setup as PK
        public int MatchID { get; set; }

        //TODO: Do the forein keys for TournamentID, Team1ID, Team2ID, and LocationID


        public int Round { get; set; }

        public string Name { get; set; }

        //DataType.Date changes the Date from DateTime to just calendar date (then updated with the display line)
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }
    }
}