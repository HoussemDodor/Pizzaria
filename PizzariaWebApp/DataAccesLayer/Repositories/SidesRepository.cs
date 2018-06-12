using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class SidesRepository : ISides
    {
        private ISides context;

        public SidesRepository()
        {
            context = new SidesSQLContext();
        }

        public void AddSideToOrder(int orderID, int sideID) => context.AddSideToOrder(orderID, sideID);

        public List<Side> GetAllSides() => context.GetAllSides();

        public List<Side> GetSideByCategory(int categoryID) => context.GetSideByCategory(categoryID);

        public Side GetSideByID(int sideID) => context.GetSideByID(sideID);

        public List<Product> GetSideByOrder(int orderID) => GetSideByOrder(orderID);
    }
}
