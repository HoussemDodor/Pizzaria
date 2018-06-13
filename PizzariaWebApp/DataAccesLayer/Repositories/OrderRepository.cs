using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class OrderRepository : IOrder
    {
        private IOrder context;

        public OrderRepository()
        {
            context = new OrderSQLContext();
        }

        public List<Order> GetAllOrders() => context.GetAllOrders();

        public List<Order> GetOrderByCustomerID(int customerID) => context.GetOrderByCustomerID(customerID);

        public Order GetOrderByID(int orderID) => context.GetOrderByID(orderID);

        public bool NewOrder(Order order) => context.NewOrder(order);
    }
}
