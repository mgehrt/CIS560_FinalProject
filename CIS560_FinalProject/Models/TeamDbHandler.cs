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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TournamentContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
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

        /*public Team ViewTeam(int id)
        {
            Connection();
            List<Match> Matches = new List<Match>();
            SqlCommand command = new SqlCommand("ViewTeam", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            command.Parameters.AddWithValue("@TournamentID", id);

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                Matches.Add(
                   new Match
                   {
                       MatchID = Convert.ToInt32(dr["@MatchID"]),
                       TournamentID = Convert.ToInt32(dr["@TournamentID"]),
                       Team1ID = Convert.ToInt32(dr["@Team1ID"]),
                       Team2ID = Convert.ToInt32(dr["@Team2ID"]),
                       LocationID = Convert.ToInt32(dr["@LocationID"]),
                       Round = Convert.ToInt32(dr["@Round"]),
                       Name = Convert.ToString(dr["@Name"]),
                       Date = Convert.ToDateTime(dr["@Date"]),
                       Team1Score = Convert.ToInt32(dr["@Team1Score"]),
                       Team2Score = Convert.ToInt32(dr["@Team2Score"])
                   });
            }
            return Matches;
        }*/
    }
}