using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class OrderSQLContext : IOrder
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Order order;

        public List<Order> GetAllOrders()
        {
            List<Order> Orders = new List<Order>();
            string query = "SELECT * FROM [Order]";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Orders.Add(CreateOrderFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return Orders;
            }
        }

        public List<Order> GetOrderByCustomerID(int customerID)
        {
            List<Order> orders = new List<Order>();
            string query = "SELECT * From [Order] WHERE CustomerID = @CustomerID";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(CreateOrderFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return orders;
            }
        }

        public Order GetOrderByID(int orderID)
        {
            string query = "SELECT * From [Order] WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", orderID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            order = CreateOrderFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return order;
            }
        }

        public bool NewOrder(Order order)
        {
            string InsertOrderQuery =  @"INSERT INTO [Order](CustomerID, DeliveryAdress, HouseNumber, HouseNumberAddition, City, DateOrderPlaced, Comment, TakeAway, Delivered)
                                        VALUES (@customerID, @deliveryAdress, @houseNumber, @houseNumberAddition, @city, @dateOrderPlaced, @comment, @takeAway, @delivered)";
            string AddPizzaToOrderQuery = @"INSERT INTO PizzaOrder(PizzaID, OrderId) VALUES (@pizzaID, @orderID)";
            string AddSideToOrderQuery = @"INSERT INTO OrderSide(SideID, OrderId) VALUES(@sideID, @orderID)";
            try
            {
                using (SqlConnection conn = dbconn.Connect)
                {
                    using (SqlCommand cmd = new SqlCommand(InsertOrderQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@customerID", order.CustomerID);
                        cmd.Parameters.AddWithValue("@deliveryAdress", order.deliveryAdress);
                        cmd.Parameters.AddWithValue("@houseNumber", order.houseNumber);
                        cmd.Parameters.AddWithValue("@houseNumberAddition", order.houseNumberAddition);
                        cmd.Parameters.AddWithValue("@city", order.city);
                        cmd.Parameters.AddWithValue("@dateOrderPlaced", order.dateOrderPlaced);
                        cmd.Parameters.AddWithValue("@comment", order.customerComment);
                        cmd.Parameters.AddWithValue("@takeAway", order.takeAway);
                        cmd.Parameters.AddWithValue("@delivered", order.Delivered);

                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand(AddPizzaToOrderQuery, conn))
                    {
                        foreach (Pizza pizza in order.productsInThisOrder)
                        {
                            cmd.Parameters.AddWithValue("@pizzaID", pizza.ID);
                            cmd.Parameters.AddWithValue("@orderID", order.ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlCommand cmd = new SqlCommand(AddSideToOrderQuery, conn))
                    {
                        foreach (Side side in order.productsInThisOrder)
                        {
                            cmd.Parameters.AddWithValue("@sideID", side.ID);
                            cmd.Parameters.AddWithValue("@orderID", order.ID);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            {
                return false;
                throw;
            }

            return true;
        }

        private List<Product> GetProductsInThisOrder(int orderID)
        {
            PizzaSQLContext pizzasql = new PizzaSQLContext();
            SidesSQLContext sidesql = new SidesSQLContext();
            List<Product> products = new List<Product>();

            foreach (Product p in pizzasql.GetPizzasByOrder(orderID))
            {
                products.Add(p);
            }
            foreach (Product p in sidesql.GetSideByOrder(orderID))
            {
                products.Add(p);
            }
            return products;
        }

        private Customer GetCustomer(int customerID) // => new CustomerRepository().GetCustomerByID(customerID);
        {
            return new CustomerRepository().GetCustomerByID(customerID);
        }

        private Order CreateOrderFromReader(SqlDataReader reader)
        {
            if (Convert.ToString(reader["HouseNumberAddition"]) == null && Convert.ToString(reader["CustomerComment"]) == null)
            {
                return new Order()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    deliveryAdress = Convert.ToString(reader["DeliveryAdress"]),
                    houseNumber = Convert.ToString(reader["HouseNumber"]),
                    city = Convert.ToString(reader["City"]),
                    dateOrderPlaced = Convert.ToDateTime(reader["DateOrderPlaced"]),
                    takeAway = Convert.ToBoolean(reader["TakeAway"]),
                    Delivered = Convert.ToBoolean(reader["Delivered"]),
                    productsInThisOrder = GetProductsInThisOrder(Convert.ToInt32(reader["ID"])),
                    Customer = GetCustomer(Convert.ToInt32(reader["CustomerID"]))
                };
            }
            else if (Convert.ToString(reader["HouseNumberAddition"]) == null && Convert.ToString(reader["Comment"]) != null)
            {
                return new Order()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    deliveryAdress = Convert.ToString(reader["DeliveryAdress"]),
                    houseNumber = Convert.ToString(reader["HouseNumber"]),
                    city = Convert.ToString(reader["City"]),
                    dateOrderPlaced = Convert.ToDateTime(reader["DateOrderPlaced"]),
                    customerComment = Convert.ToString(reader["Comment"]),
                    takeAway = Convert.ToBoolean(reader["TakeAway"]),
                    Delivered = Convert.ToBoolean(reader["Delivered"]),
                    productsInThisOrder = GetProductsInThisOrder(Convert.ToInt32(reader["ID"])),
                    Customer = GetCustomer(Convert.ToInt32(reader["CustomerID"]))
                };
            }
            else if (Convert.ToString(reader["HouseNumberAddition"]) != null && Convert.ToString(reader["Comment"]) == null)
            {
                return new Order()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    deliveryAdress = Convert.ToString(reader["DeliveryAdress"]),
                    houseNumber = Convert.ToString(reader["HouseNumber"]),
                    houseNumberAddition = Convert.ToString(reader["HouseNumberAddition"]),
                    city = Convert.ToString(reader["City"]),
                    dateOrderPlaced = Convert.ToDateTime(reader["DateOrderPlaced"]),
                    takeAway = Convert.ToBoolean(reader["TakeAway"]),
                    Delivered = Convert.ToBoolean(reader["Delivered"]),
                    productsInThisOrder = GetProductsInThisOrder(Convert.ToInt32(reader["ID"])),
                    Customer = GetCustomer(Convert.ToInt32(reader["CustomerID"]))
                };
            }
            else
            {
                return new Order()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    CustomerID = Convert.ToInt32(reader["CustomerID"]),
                    deliveryAdress = Convert.ToString(reader["DeliveryAdress"]),
                    houseNumber = Convert.ToString(reader["HouseNumber"]),
                    houseNumberAddition = Convert.ToString(reader["HouseNumberAddition"]),
                    city = Convert.ToString(reader["City"]),
                    dateOrderPlaced = Convert.ToDateTime(reader["DateOrderPlaced"]),
                    customerComment = Convert.ToString(reader["Comment"]),
                    takeAway = Convert.ToBoolean(reader["TakeAway"]),
                    Delivered = Convert.ToBoolean(reader["Delivered"]),
                    productsInThisOrder = GetProductsInThisOrder(Convert.ToInt32(reader["ID"])),
                    Customer = GetCustomer(Convert.ToInt32(reader["CustomerID"]))
                };
            }
        }
    }
}
