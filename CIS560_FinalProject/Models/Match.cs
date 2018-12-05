using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CIS560_FinalProject.Models
{
    public class Match
    {
        //MatchID is automatically setup as PK
        public int MatchID { get; set; }
        public int TournamentID { get; set; }
        public int Team1ID { get; set; }
        public int Team2ID { get; set; }
        public int LocationID { get; set; }
        public string Round { get; set; }
        public string Name { get; set; }
        //DataType.Date changes the Date from DateTime to just calendar date (then updated with the display line)
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        public int Team1Score { get; set; }
        public int Team2Score { get; set; }
        public virtual Team Team1 { get; set; }
        public virtual Team Team2 { get; set; }
        public virtual Location Location { get; set; }
        //public Match(int MatchID, int TournamentID, int Team1ID, int Team2ID, int LocationID, string Round, string Name, DateTime Date, int Team1Score, int Team2Score)
        //{

        //}
    }
}