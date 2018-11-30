using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS560_FinalProject.Models
{
    public class TournamentDbHandle
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CIS560FinalProject"].ToString();
            con = new SqlConnection(connectionString);
        }


        public bool AddTournament(Tournament t)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreateTournament", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Name", t.Name);
            command.Parameters.AddWithValue("@Sport", t.Sport);
            command.Parameters.AddWithValue("@StartDate", t.StartDate);
            command.Parameters.AddWithValue("@EndDate", t.EndDate);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Tournament> GetTournaments()
        {
            Connection();
            List<Tournament> tournaments = new List<Tournament>();

            SqlCommand command = new SqlCommand("GetTournaments", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach(DataRow dr in dt.Rows)
            {
                tournaments.Add(
                    new Tournament
                    {
                        TournamentID = Convert.ToInt32(dr["TournamentID"]),
                        Name = Convert.ToString(dr["Name"]),
                        Sport = Convert.ToString(dr["Sport"]),
                        StartDate = Convert.ToDateTime(dr["StartDate"]),
                        EndDate = Convert.ToDateTime(dr["EndDate"])
                    });
            }
            return tournaments;
        }

        public bool UpdateTournament(Tournament t)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateTournament", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@TournamentID", t.TournamentID);
            command.Parameters.AddWithValue("@Name", t.Name);
            command.Parameters.AddWithValue("@Sport", t.Sport);
            command.Parameters.AddWithValue("@StartDate", t.StartDate);
            command.Parameters.AddWithValue("@EndDate", t.EndDate);


            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeleteTournament(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteTournament", con);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@TournamentID", id);

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