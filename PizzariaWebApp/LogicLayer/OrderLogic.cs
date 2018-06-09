using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using Models;

namespace LogicLayer
{
    public class OrderLogic
    {
        OrderRepository repo;

        public OrderLogic()
        {
            repo = new OrderRepository();
        }

        public List<Order> GetAllOrders() => repo.GetAllOrders();

        public List<Pizza> GetAllPizzaByOrder(int orderID) => repo.GetAllPizzaByOrder(orderID);

        public List<Side> GetAllSidesByOrder(int orderID) => repo.GetAllSidesByOrder(orderID);

        public List<Order> GetOrderByCustomerID(int customerID) => repo.GetOrderByCustomerID(customerID);

        public Order GetOrderByID(int orderID) => repo.GetOrderByID(orderID);
        bool NewOrder(Order order) => repo.NewOrder(order);
    }
}
