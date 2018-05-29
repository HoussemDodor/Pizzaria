using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class SidesRepository
    {
        private ISides context;

        public SidesRepository()
        {
            context = new SidesSQLContext();
        }

        public List<Side> GetAllSides()
        {
            return context.GetAllSides();
        }

        public List<Side> GetSideByCategory(int categoryID)
        {
            return context.GetSideByCategory(categoryID);
        }

        public Side GetSideByID(int sideID)
        {
            return context.GetSideByID(sideID);
        }
    }
}
