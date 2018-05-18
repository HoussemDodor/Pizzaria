using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class CustomerSQLContext : ICustomer
    {
        private DatabaseConnection dbconn = new DatabaseConnection();
        private Customer customer;
        private List<Customer> customerList = new List<Customer>();


        public List<Customer> GetAllCustomers()
        {
            customerList.Clear();
            string query = "SELECT * FROM Customer";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            customerList.Add(CreateCustomerFromReader(reader));
                        }
                    }
                }
                conn.Close();
            }
            return customerList;
        }

        public Customer GetCustomerByID(int customerID)
        {
            string query = "SELECT * FROM Customer WHERE ID = @id;";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", customerID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = CreateCustomerFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return customer;
            }
        }

        public Customer Login(string email, string password)
        {
            string query = "SELECT * FROM Customer WHERE Email = @email AND Password = @password;";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customer = CreateCustomerFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return customer;
            }
        }

        public Customer Register(string name, string surname, string email, string password, bool admin)
        {
            string query = "INSERT INTO Customer(Name, Surname, Email, Password, Admin) VALUES(@name, @surname, @email, @password, @admin);";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@admin", admin);
                    cmd.ExecuteNonQuery();                                                    
                }
                conn.Close();
                return Login(email, password);
            }
        }

        private Customer CreateCustomerFromReader(SqlDataReader reader)
        {
            return new Customer()
            {
                ID = Convert.ToInt32(reader["ID"]),
                mail = Convert.ToString(reader["Email"]),
                password = Convert.ToString(reader["Password"]),
                name = Convert.ToString(reader["Name"]),
                surName = Convert.ToString(reader["Surname"]),
                admin = Convert.ToBoolean(reader["Admin"])
            };
        }
    }
}
