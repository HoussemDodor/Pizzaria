using System;
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
        List<Topping> GetToppingByPizza(int PizzaID);
        DoughType GetDoughType(int doughtTypeID);
        Shape GetShape(int shapeID);
    }
}
