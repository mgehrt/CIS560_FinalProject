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
            string connectionString = @"Data Source=mssql.cs.ksu.edu;Initial Catalog=jrvictor;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectionString);
        }


        public bool AddPlayer(Player p)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreatePlayer", con);//Need a procedure for this
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@FirstName", p.FirstName);
            command.Parameters.AddWithValue("@LastName", p.LastName);
            command.Parameters.AddWithValue("@TeamName", p.Team);
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
            command.Parameters.AddWithValue("@TeamID", p.TeamID);
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

            SqlCommand command = new SqlCommand("GetPlayers", con);
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
                        TeamID = Convert.ToInt32(dr["TeamID"]),
                        FirstName = Convert.ToString(dr["FirstName"]),
                        LastName = Convert.ToString(dr["LastName"]),
                        Number = Convert.ToInt32(dr["Number"]),
                        Team = Convert.ToString(dr["Team"])
                    });
            }
            return players;
        }

        public Player ViewPlayer(int id)
        {
            Connection();
            Player Player = new Player();
            SqlCommand command = new SqlCommand("GetPlayer", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@PlayerID", id);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            

            con.Open();
            sda.Fill(dt);
            con.Close();
            //Only one so it's fine
            foreach (DataRow dr in dt.Rows)
            {
                Player =
                   new Player
                   {
                       PlayerID = id,
                       TeamID = Convert.ToInt32(dr["TeamID"]),
                       FirstName = Convert.ToString(dr["FirstName"]),
                       LastName = Convert.ToString(dr["LastName"]),
                       Number = Convert.ToInt32(dr["Number"]),
                       Team = Convert.ToString(dr["Team"])
                   };
            }
            return Player;
        }

        public int SearchPlayer(string text)
        {
            Connection();
            SqlCommand command = new SqlCommand("SearchPlayer", con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@SearchString", text);
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();
            int i = 1;
            foreach(DataRow dr in dt.Rows)
            {
                 i = Convert.ToInt32(dr["PlayerID"]);
            }

            return i;
        }
    }
}