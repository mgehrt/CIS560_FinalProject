using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS560_FinalProject.Models
{
    public class MatchDbHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CIS560FinalProject"].ToString();
            con = new SqlConnection(connectionString);
        }

        public bool AddMatch(Match m)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreateMatch", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@TournamentID", m.TournamentID);
            command.Parameters.AddWithValue("@LocationID", m.LocationID);
            command.Parameters.AddWithValue("@Round", m.Round);
            command.Parameters.AddWithValue("@Name", m.Name);
            command.Parameters.AddWithValue("@Date", m.Date);
            command.Parameters.AddWithValue("@Team1Score", m.Team1Score);
            command.Parameters.AddWithValue("@Team2Score", m.Team2Score);
            command.Parameters.AddWithValue("@Team1ID", m.Team1ID);
            command.Parameters.AddWithValue("@Team2ID", m.Team2ID);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }
    }
}