﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface ISides
    {
        List<Side> GetAllSides();
        Side GetSideByID(int sideID);
        List<Side> GetSideByCategory(int categoryID);
        List<Product> GetSideByOrder(int orderID);
        void AddSideToOrder(int orderID, int sideID);
    }
}
