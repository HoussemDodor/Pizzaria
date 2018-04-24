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

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered)
        {
            return context.NewOrder(customerID, orderPlaced, takeAway, delivered);
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string comment)
        {
            return context.NewOrder(customerID, orderPlaced, takeAway, delivered, comment);
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string city)
        {
            return context.NewOrder(customerID, orderPlaced, takeAway, delivered, deliveryAdress, houseNumber, city);
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city)
        {
            return context.NewOrder(customerID, orderPlaced, takeAway, delivered, deliveryAdress, houseNumber, houseNumberAddition, city);
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city, string comment)
        {
            return context.NewOrder(customerID, orderPlaced, takeAway, delivered, deliveryAdress, houseNumber, houseNumberAddition, city, comment);
        }
    }
}
