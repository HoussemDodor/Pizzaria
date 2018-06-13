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

        public Pizza GetPizzaByID(int pizzaID)
        {
            string query = "SELECT * FROM Pizza WHERE ID = @id";
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

        public List<Product> GetPizzasByOrder(int orderID)
        {
            List<Product> products = new List<Product>();
            using (SqlConnection conn = dbconn.Connect)
            {
                SqlCommand cmd = new SqlCommand("GetPizzasInOrder", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@orderID", orderID);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < Convert.ToInt32(reader["Quantity"]); i++)
                        {
                            products.Add(CreatePizzaFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return products;
            }
        }

        public void AddPizzaToOrder(int orderID, int pizzaID)
        {
            string query = "INSERT INTO PizzaOrder(PizzaID, OrderID, Quantity) VALUES (@pizzaID, @orderID, 1)";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pizzaID", pizzaID);
                    cmd.Parameters.AddWithValue("@orderID", orderID);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private Shape GetShape(int shapeID)
        {
            ShapeSQLContext sql = new ShapeSQLContext();
            return sql.GetShapeByID(shapeID);
        }

        private List<Topping> GetToppingByPizza(int PizzaID)
        {
            ToppingSQLContext sql = new ToppingSQLContext();
            return sql.GetToppingsByPizza(PizzaID);
        }
        private DoughType GetDoughType(int doughtTypeID)
        {
            DoughTypeSQLContext sql = new DoughTypeSQLContext();
            return sql.GetDoughTypeByID(doughtTypeID);
        }

        private Pizza CreatePizzaFromReader(SqlDataReader reader)
        {
            return new Pizza()
            {
                ID = Convert.ToInt32(reader["ID"]),
                DoughID = Convert.ToInt32(reader["DoughTypeID"]),
                ShapeID = Convert.ToInt32(reader["ShapeID"]),
                Length = Convert.ToInt32(reader["Length"]),
                Width = Convert.ToInt32(reader["Width"]),
                SideLength = Convert.ToInt32(reader["SideLength"]),
                StandardPizza = Convert.ToBoolean(reader["StandardPizza"]),
                Shape = GetShape(Convert.ToInt32(reader["ShapeID"])),
                DoughType = GetDoughType(Convert.ToInt32(reader["DoughTypeID"])),
                ToppingsList = GetToppingByPizza(Convert.ToInt32(reader["ID"]))
            };
        }
    }
}

