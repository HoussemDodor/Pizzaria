using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class SidesSQLContext : ISides
    {
        public List<Side> GetAllSides()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryBySide(int categoryID)
        {
            throw new NotImplementedException();
        }

        public Side GetSideByID(int sideID)
        {
            throw new NotImplementedException();
        }
    }
}
