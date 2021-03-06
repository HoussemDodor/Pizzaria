﻿using System;
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

        public List<Order> GetOrderByCustomerID(int customerID) => repo.GetOrderByCustomerID(customerID);

        public Order GetOrderByID(int orderID) => repo.GetOrderByID(orderID);

        public bool NewOrder(Order order) => repo.NewOrder(order);
    }
}
