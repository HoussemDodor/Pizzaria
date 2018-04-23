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
        public List<DoughType> GetAllDoughTypes()
        {
            throw new NotImplementedException();
        }

        public DoughType GetDoughTypeByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
