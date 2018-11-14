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

        /*
         * GOTO: https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
         * To read more about models in EF and the foreign key relationships
         */
        public int TournamentID { get; set; }

        public int Team1ID { get; set; }

        public int Team2ID { get; set; }

        public int LocationID { get; set; }

        public int Round { get; set; }

        public string Name { get; set; }

        //DataType.Date changes the Date from DateTime to just calendar date (then updated with the display line)
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public int Team1Score { get; set; }

        public int Team2Score { get; set; }

        public virtual Team Team1 { get; set; }

        public virtual Team Team2 { get; set; }

        public virtual Location Location { get; set; }
    }
}