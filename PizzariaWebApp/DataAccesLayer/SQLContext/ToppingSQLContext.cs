using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class ToppingSQLContext : ITopping
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Topping topping;

        public List<Topping> GetAllToppings()
        {
            List<Topping> toppings = new List<Topping>();
            string query = "SELECT * FROM Topping";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            toppings.Add(CreateToppingFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return toppings;
            }
        }

        public Topping GetToppingByID(int toppingID)
        {
            string query = "SELECT * FROM Topping WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", toppingID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            topping = CreateToppingFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return topping;
            }
        }

        public List<Topping> GetToppingsByPizza(int pizzaID)
        {
            /*
             * Deze stored procedure opslaan op andere pc
             * 
                CREATE PROCEDURE dbo.GetToppingsByPizza 
                @pizzaID int
                AS
                SELECT Topping.* FROM Topping 
                INNER JOIN PizzaTopping ON Topping.ID = PizzaTopping.ToppingID
                INNER JOIN Pizza ON PizzaTopping.PizzaID = Pizza.ID
                WHERE Pizza.ID = @pizzaID
                GO

             */

            List<Topping> toppings = new List<Topping>();
            using (SqlConnection conn = dbconn.Connect)
            {
                SqlCommand cmd = new SqlCommand("GetToppingsByPizza", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pizzaID", pizzaID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        toppings.Add(CreateToppingFromReader(reader));
                    }
                }
                conn.Close();
                return toppings;
            }
        }

        private Topping CreateToppingFromReader(SqlDataReader reader)
        {
            return new Topping()
            {
                ID = Convert.ToInt32(reader["ID"]),
                name = Convert.ToString(reader["Name"]),
                price = Convert.ToDecimal(reader["Price"]),
                buyInPrice = Convert.ToDecimal(reader["BuyInPrice"]),
                halal = Convert.ToBoolean(reader["Halal"]),
                vegan = Convert.ToBoolean(reader["Vegan"])
            };
        }
    }
}
