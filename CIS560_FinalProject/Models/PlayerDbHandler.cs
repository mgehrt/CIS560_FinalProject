using System;
using System.Collections.Generic;
using System.Web.Http;
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
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TournamentContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectionString);
        }


        public bool AddPlayer(Player p)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreatePlayer", con);//Need a procedure for this
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", p.FirstName);
            command.Parameters.AddWithValue("@LastName", p.LastName);
            command.Parameters.AddWithValue("@PlayerID", p.PlayerID);
            command.Parameters.AddWithValue("@Number", p.Number);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool UpdatePlayer(Player p)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdatePlayer", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@PlayerID", p.PlayerID);
            command.Parameters.AddWithValue("@FirstName", p.FirstName);
            command.Parameters.AddWithValue("@LastName", p.LastName);
            command.Parameters.AddWithValue("@Number", p.Number);


            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeletePlayer(int id)
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

        public List<Player> GetPlayers()
        {
            Connection();
            List<Player> players = new List<Player>();

            SqlCommand command = new SqlCommand("GetPlayer", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                players.Add(
                    new Player
                    {
                        PlayerID = Convert.ToInt32(dr["PlayerID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Number = Convert.ToInt32(dr["Number"])
                    });
            }
            return players;
        }

        public List<Player> ViewPlayer(int id)
        {
            Connection();
            List<Player> Players = new List<Player>();
            SqlCommand command = new SqlCommand("ViewPlayer", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            command.Parameters.AddWithValue("@PlayerID", id);

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
                       Number = Convert.ToInt32(dr["Number"])
                   });
            }
            return Players;
        }
    }
}