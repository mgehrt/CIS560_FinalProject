using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CIS560_FinalProject.Models
{
    public class LocationDbHandler
    {
        private SqlConnection con;
        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CIS560FinalProject"].ToString();
            con = new SqlConnection(connectionString);
        }


        public bool AddLocation(Location l)
        {
            Connection();
            SqlCommand command = new SqlCommand("CreateLocation", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@Venue", l.Venue);
            command.Parameters.AddWithValue("@City", l.City);
            command.Parameters.AddWithValue("@StateProvince", l.StateProvince);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Location> GetLocations()
        {
            Connection();
            List<Location> locations = new List<Location>();

            SqlCommand command = new SqlCommand("GetLocations", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                locations.Add(
                    new Location
                    {
                        LocationID = Convert.ToInt32(dr["LocationID"]),
                        Venue = Convert.ToString(dr["Venue"]),
                        City = Convert.ToString(dr["City"]),
                        StateProvince = Convert.ToString(dr["StateProvince"])
                    });
            }
            return locations;
        }

        public bool updateLocation(Location l)
        {
            Connection();
            SqlCommand command = new SqlCommand("UpdateLocation", con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@LocationID", l.LocationID);
            command.Parameters.AddWithValue("@Venue", l.Venue);
            command.Parameters.AddWithValue("@City", l.City);
            command.Parameters.AddWithValue("@StateProvince", l.StateProvince);


            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public bool DeleteLocation(int id)
        {
            Connection();
            SqlCommand command = new SqlCommand("DeleteLocation", con);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.AddWithValue("@LocationID", id);

            con.Open();
            int i = command.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        public List<Location> ViewLocation(int id)
        {
            Connection();
            List<Location> Locations = new List<Location>();
            SqlCommand command = new SqlCommand("ViewLocation", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            command.Parameters.AddWithValue("@LocationID", id);

            con.Open();
            sda.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                Locations.Add(
                   new Location
                   {
                       LocationID = Convert.ToInt32(dr["@LocationID"]),
                       Venue = Convert.ToString(dr["@Venue"]),
                       City = Convert.ToString(dr["@City"]),
                       StateProvince = Convert.ToString(dr["@StateProvince"])
                   });
            }
            return Locations;
        }
    }
}