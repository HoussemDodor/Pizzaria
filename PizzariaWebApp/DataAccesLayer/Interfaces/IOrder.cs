using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface IOrder
    {
        // order zonder adres en zonder comment
        bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered);
        // order zonder adres en met comment
        bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string comment);
        // order met adres zonder comment
        bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city);
        // order met adres en met comment
        bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string houseNumberAddition, string city, string comment);
        // order zonder housenumberaddition zonder comment
        bool NewOrder(int customerID, DateTime orderPlaced, bool takeAway, bool delivered, string deliveryAdress, string houseNumber, string city);
        List<Order> GetAllOrders();
        Order GetOrderByID(int orderID);
        List<Order> GetOrderByCustomerID(int customerID);
        List<Pizza> GetAllPizzaByOrder(int orderID);
        List<Side> GetAllSidesByOrder(int orderID);    
    }
}
