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
        bool NewOrder(Order order);
        List<Order> GetAllOrders();
        Order GetOrderByID(int orderID);
        List<Order> GetOrderByCustomerID(int customerID);
    }
}
