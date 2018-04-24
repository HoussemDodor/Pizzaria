using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class DoughTypeSQLContext : IDoughType
    {
        private DatabaseConnection dbconn = new DatabaseConnection();
        DoughType doughType;

        public List<DoughType> GetAllDoughTypes()
        {
            List<DoughType> DoughTypeList = new List<DoughType>();
            string query = "SELECT * FROM DoughType";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DoughTypeList.Add(CreateDoughTypeFromReader(reader));
                        }
                    }
                }
                conn.Close();
                return DoughTypeList;
            }
        }

        public DoughType GetDoughTypeByID(int ID)
        {
            string query = "SELECT * FROM DoughType WHERE ID = @id";
            using (SqlConnection conn = dbconn.Connect)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", ID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            doughType = CreateDoughTypeFromReader(reader);
                        }
                    }
                }
                conn.Close();
                return doughType;
            }
        }

        private DoughType CreateDoughTypeFromReader(SqlDataReader reader)
        {
            return new DoughType
                (
                    Convert.ToInt32(reader["ID"]),
                    Convert.ToString(reader["Name"]),
                    Convert.ToDecimal(reader["Price"]),
                    Convert.ToDecimal(reader["BuyInPrice"])
                );
        }
    }
}
