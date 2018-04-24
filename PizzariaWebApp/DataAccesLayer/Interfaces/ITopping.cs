﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface ITopping
    {
        List<Topping> GetAllToppings();
        Topping GetToppingByID(int toppingID);
    }
}
