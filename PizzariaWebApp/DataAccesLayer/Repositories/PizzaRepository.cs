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

        public List<Pizza> GetAllPizzas() => context.GetAllPizzas();

        public Pizza GetPizzaByID(int pizzaID) => context.GetPizzaByID(pizzaID);
    }
}
