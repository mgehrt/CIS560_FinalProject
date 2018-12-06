using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS560_FinalProject.Models
{
    public class TeamDbHandler : ApiController
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = @"Data Source=mssql.cs.ksu.edu;Initial Catalog=jrvictor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectionString);
        }


        public bool AddTeam(Team t)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreateTeam", con);//Need a procedure for this
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", t.Name);
            command.Parameters.AddWithValue("@LocationID", t.LocationID);
            command.Parameters.AddWithValue("@Mascot", t.Mascot);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool UpdateTeam(Team t)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateTeam", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@TeamID", t.TeamID);
            command.Parameters.AddWithValue("@Name", t.Name);
            command.Parameters.AddWithValue("@LocationID", t.LocationID);
            command.Parameters.AddWithValue("@Mascot", t.Mascot);


            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeleteTeam(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteTeam", con);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@TeamID", id);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Team> GetTeams()
        {
            Connection();
            List<Team> teams = new List<Team>();

            SqlCommand command = new SqlCommand("GetTeams", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                
                teams.Add(
                    new Team 
                    {
                        TeamID = Convert.ToInt32(dr["TeamID"]),
                        Name = Convert.ToString(dr["Name"]),
                        LocationID = Convert.ToInt32(dr["LocationID"]),
                        Mascot = Convert.ToString(dr["Mascot"]),
                        Location = new Location(Convert.ToInt32(dr["LocationID"]), Convert.ToString(dr["Venue"]), Convert.ToString(dr["City"]), Convert.ToString(dr["StateProvince"]))
                        
                    });
            }
            return teams;
        }

        public List<Player> ViewTeam(int id)
        {
            Connection();
            List<Player> Players = new List<Player>();
            SqlCommand command = new SqlCommand("ViewTeam", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            command.Parameters.AddWithValue("@TeamID", id);

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                Players.Add(
                   new Player
                   {
                       PlayerID = Convert.ToInt32(dr["PlayerID"]),
                       FirstName = Convert.ToString(dr["FirstName"]),
                       LastName = Convert.ToString(dr["LastName"]),
                       Number = Convert.ToInt32(dr["Number"]),
                       TeamID = Convert.ToInt32(dr["TeamID"])
                   });
            }
            return Players;
        }
    }
}