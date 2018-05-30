using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class ShapeSQLContext : IShape
    {
        DatabaseConnection dbconn = new DatabaseConnection();
        Shape shape;

        public List<Shape> GetAllShapes()
        {
            List<Shape> shapes = new List<Shape>();
            string query = "SELECT * FROM Shape";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            shapes.Add(CreateShapeFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return shapes;
            }
        }

        public Shape GetShapeByID(int shapeID)
        {
            string query = "SELECT * FROM Shape WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", shapeID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            shape = CreateShapeFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return shape;
            }
        }

        private Shape CreateShapeFromReader(SqlDataReader reader)
        {
            if (Convert.ToString(reader["Name"]) == "Circle")
            {
                return new Circle()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    name = Convert.ToString(reader["Name"])
                };
            }
            else if (Convert.ToString(reader["Name"]) == "Triangle")
            {
                return new Triangle()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    name = Convert.ToString(reader["Name"])
                };
            }
            else
            {
                return new Rectangle()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    name = Convert.ToString(reader["Name"])
                };
            }
        }
    }
}
