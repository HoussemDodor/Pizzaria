using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class PizzaSQLContext : IPizza
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Pizza pizza; 

        public List<Pizza> GetAllPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            string query = "SELECT * FROM Pizza";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pizzas.Add(CreatePizzaFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return pizzas;
            }
        }

        public DoughType GetDoughType(int doughtTypeID)
        {
            DoughTypeSQLContext sql = new DoughTypeSQLContext();
            return sql.GetDoughTypeByID(doughtTypeID);
        }

        public Pizza GetPizzaByID(int pizzaID)
        {
            string query = "SELECT * FROM Pizzaz WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", pizzaID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pizza = CreatePizzaFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return pizza;
            }
        }

        public Shape GetShape(int shapeID)
        {
            ShapeSQLContext sql = new ShapeSQLContext();
            return sql.GetShapeByID(shapeID);
        }

        public List<Topping> GetToppingByPizza(int PizzaID)
        {
            ToppingSQLContext sql = new ToppingSQLContext();
            return sql.GetToppingsByPizza(PizzaID);
        }

        private Pizza CreatePizzaFromReader(SqlDataReader reader)
        {
            return new Pizza()
            {
                ID = Convert.ToInt32(reader["ID"]),
                DoughID = Convert.ToInt32(reader["DoughID"]),
                ShapeID = Convert.ToInt32(reader["ShapeID"]),
                Length = Convert.ToInt32(reader["Length"]),
                Width = Convert.ToInt32(reader["Width"]),
                SideLength = Convert.ToInt32(reader["SideLength"]),
                StandardPizza = Convert.ToBoolean(reader["StandardPizza"]),
                Shape = GetShape(Convert.ToInt32(reader["ShapeID"])),
                DoughType = GetDoughType(Convert.ToInt32(reader["DoughID"])),
                ToppingsList = GetToppingByPizza(Convert.ToInt32(reader["ID"]))
            };
        }
    }
}

