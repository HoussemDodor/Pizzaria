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

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string comment)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string city)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city)
        {
            throw new NotImplementedException();
        }

        public bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city, string comment)
        {
            throw new NotImplementedException();
        }
    }
}
