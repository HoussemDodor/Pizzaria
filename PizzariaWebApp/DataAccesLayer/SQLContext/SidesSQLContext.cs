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

        public List<Product> GetSideByOrder(int orderID)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = dbconn.Connect)
            {
                SqlCommand cmd = new SqlCommand("GetSidesInOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderID", orderID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < Convert.ToInt32(reader["Quantity"]); i++)
                        {
                            products.Add(CreateSideFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return products;
            }
        }

        private Side CreateSideFromReader(SqlDataReader reader)
        {
            return new Side()
            {
                ID = Convert.ToInt32(reader["ID"]),
                SideName = Convert.ToString(reader["Name"]),
                SidePrice = Convert.ToDecimal(reader["Price"]),
                BuyInPrice = Convert.ToDecimal(reader["BuyInPrice"]),
                Halal = Convert.ToBoolean(reader["Halal"]),
                Vegan = Convert.ToBoolean(reader["Vegan"]),
                Alcohol = Convert.ToBoolean(reader["Alcohol"]),
                CategoryID = Convert.ToInt32(reader["CategoryID"])
            };
        }
    }
}
