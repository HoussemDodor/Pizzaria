using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class PizzaSQLContext : IPizza
    {
        public List<Pizza> GetAllPizzas()
        {
            throw new NotImplementedException();
        }

        public DoughType GetDoughType(int doughtTypeID)
        {
            throw new NotImplementedException();
        }

        public Pizza GetPizzaByID(int pizzaID)
        {
            throw new NotImplementedException();
        }

        public Shape GetShape(int shapeID)
        {
            throw new NotImplementedException();
        }

        public List<Topping> GetToppingByPizza(int PizzaID)
        {
            throw new NotImplementedException();
        }
    }
}
