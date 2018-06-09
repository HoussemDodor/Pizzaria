using System;
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
        List<Topping> GetToppingsByPizza(int pizzaID);
        Topping GetToppingByID(int toppingID);

    }
}
