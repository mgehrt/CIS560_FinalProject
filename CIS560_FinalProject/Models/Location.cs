using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CIS560_FinalProject.Models
{
    public class Location
    {
        
        public int LocationID { get; set; }

        public string Venue { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }
    }
}