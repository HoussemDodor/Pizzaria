using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    internal class DatabaseConnection
    {
        private const string connectionString = "Server=tcp:houssemazure.database.windows.net,1433;Initial Catalog=PizzariaCasus;Persist Security Info=False;User ID=H.Dodor;Password=Blyker887;";

        public SqlConnection Connect
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);

                try
                {
                    connection.Open();
                }
                catch
                {
                    connection.Close();
                }
                return connection;
            }
            set
            {
                Connect = value;
            }
        }
    }
}
