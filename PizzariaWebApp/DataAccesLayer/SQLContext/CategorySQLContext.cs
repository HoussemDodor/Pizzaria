using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class CategorySQLContext : ICategory
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Category category;

        public List<Category> GetAllCategory()
        {
            List<Category> categorys = new List<Category>();
            string query = "SELECT * FROM Category";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            categorys.Add(CreateCategoryFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return categorys;
            }
        }

        public Category GetCategoryByID(int categoryID)
        {
            string query = "SELECT * FROM Category WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", categoryID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category = CreateCategoryFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return category;
            }
        }

        private Category CreateCategoryFromReader(SqlDataReader reader)
        {
            return new Category()
            {
                ID = Convert.ToInt32(reader["ID"]),
                name = Convert.ToString(reader["Name"])
            };
        }
    }
}
