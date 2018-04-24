using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class PizzaRepository
    {
        private IPizza context;

        public PizzaRepository()
        {
            context = new PizzaSQLContext();
        }

        public List<Pizza> GetAllPizzas()
        {
            return context.GetAllPizzas();
        }

        public DoughType GetDoughType(int doughtTypeID)
        {
            return context.GetDoughType(doughtTypeID);
        }

        public Pizza GetPizzaByID(int pizzaID)
        {
            return context.GetPizzaByID(pizzaID);
        }

        public Shape GetShape(int shapeID)
        {
            return context.GetShape(shapeID);
        }

        public List<Topping> GetToppingByPizza(int PizzaID)
        {
            return GetToppingByPizza(PizzaID);
        }
    }
}
