using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class OrderRepository
    {
        private IOrder context;

        public OrderRepository()
        {
            context = new OrderSQLContext();
        }

        public List<Order> GetAllOrders()
        {
            return context.GetAllOrders();
        }

        public List<Pizza> GetAllPizzaByOrder(int orderID)
        {
            return context.GetAllPizzaByOrder(orderID);
        }

        public List<Side> GetAllSidesByOrder(int orderID)
        {
            return context.GetAllSidesByOrder(orderID);
        }

        public List<Order> GetOrderByCustomerID(int customerID)
        {
            return context.GetOrderByCustomerID(customerID);
        }

        public Order GetOrderByID(int orderID)
        {
            return context.GetOrderByID(orderID);
        }

        public bool NewOrder(Order order)
        {
            return context.NewOrder(order);
        }
    }
}
