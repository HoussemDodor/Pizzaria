﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface IPizza
    {
        List<Pizza> GetAllPizzas();
        Pizza GetPizzaByID(int pizzaID);
        List<Product> GetPizzasByOrder(int orderID);
        void AddPizzaToOrder(int orderID, int pizzaID);
    }
}
