using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS560_FinalProject.Models
{
    public class PlayerDbHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CIS560FinalProject"].ToString();
            con = new SqlConnection(connectionString);
        }


        public bool AddTeam(Team t)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreatePlayer", con);//Need a procedure for this
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", t.FirstName);
            command.Parameters.AddWithValue("@LastName", t.LastName);
            command.Parameters.AddWithValue("@PlayerID", t.PlayerID);
            command.Parameters.AddWithValue("@Number", t.Number);

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
            SqlCommand command = new SqlCommand("UpdatePlayer", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PlayerID", t.PlayerID);
            command.Parameters.AddWithValue("@FirstName", t.FirstName);
            cocommand.Parameters.AddWithValue("@LastName", t.LastName);
            command.Parameters.AddWithValue("@Number", t.Number);


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
            SqlCommand command = new SqlCommand("DeletePlayer", con);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@PlayerID", id);

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

            SqlCommand command = new SqlCommand("GetPlayer", con);
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
                        PlayerID = Convert.ToInt32(dr["PlayerID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Number = Convert.ToInt32(dr["Number"])
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