using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class DoughTypeRepository : IDoughType
    {
        private IDoughType context;

        public DoughTypeRepository()
        {
            context = new DoughTypeSQLContext();
        }

        public List<DoughType> GetAllDoughTypes()
        {
            return context.GetAllDoughTypes();
        }

        public DoughType GetDoughTypeByID(int ID)
        {
            return context.GetDoughTypeByID(ID);
        }
    }
}
