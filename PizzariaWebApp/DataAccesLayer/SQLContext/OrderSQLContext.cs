using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class OrderSQLContext : IOrder
    {
        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetAllPizzaByOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Side> GetAllSidesByOrder(int orderID)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrderByCustomerID(int customerID)
        {
            throw new NotImplementedException();
        }

        public Order GetOrderByID(int orderID)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
