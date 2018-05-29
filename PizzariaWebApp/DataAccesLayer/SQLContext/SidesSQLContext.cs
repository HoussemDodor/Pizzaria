using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class SidesSQLContext : ISides
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Side side;
        public List<Side> GetAllSides()
        {
            List<Side> sides = new List<Side>();
            string query = "SELECT * FROM Side";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sides.Add(CreateSideFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return sides;
            }
        }

        public List<Side> GetSideByCategory(int categoryID)
        {
            List<Side> sides = new List<Side>();
            string query = "SELECT * FROM Side WHERE CategoryID = @categoryID";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("categoryID", categoryID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sides.Add(CreateSideFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return sides;
            }
        }

        public Side GetSideByID(int sideID)
        {
            string query = "SELECT * FROM Side WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", sideID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            side = CreateSideFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return side;
            }
        }

        private Side CreateSideFromReader(SqlDataReader reader)
        {
            return new Side()
            {
                ID = Convert.ToInt32(reader["ID"]),
                name = Convert.ToString(reader["Name"]),
                price = Convert.ToDecimal(reader["Price"]),
                buyInPrice = Convert.ToDecimal(reader["BuyInPrice"]),
                halal = Convert.ToBoolean(reader["Halal"]),
                vegan = Convert.ToBoolean(reader["Vegan"]),
                alcohol = Convert.ToBoolean(reader["Alcohol"]),
                categoryID = Convert.ToInt32(reader["CategoryID"])
            };
        }
    }
}
