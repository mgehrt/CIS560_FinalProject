using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS560_FinalProject.EF;
using System.Data.Entity;
using CIS560_FinalProject.Models;
using System.Data.SqlClient;

namespace CIS560_FinalProject.Controllers
{
    public class TeamController : Controller
    {
        public TournamentContext db = new TournamentContext();

        // GET: Team
        public ActionResult Index()
        {
            //would like to use sql instead of other stuff
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = "SELECT * FROM dbo.Tournaments";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                try
                {
                    cnn.Open();
                    SqlCommand sqlCommand = new SqlCommand(queryString, cnn);
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        var list = new List<Tournament>();
                        while (dataReader.Read())
                        {
                            var name = dataReader["Name"];
                            var sport = dataReader["Sport"];
                            var id = dataReader["TournamentID"];
                        }
                    }
                }
                catch (Exception ee)
                {

                }

                return View();
            }
        }

        public ActionResult Create()
        {
            return View();
        }


    }
}