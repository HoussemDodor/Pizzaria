using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class PizzaRepository : IPizza
    {
        private IPizza context;

        public PizzaRepository()
        {
            context = new PizzaSQLContext();
        }

        public void AddPizzaToOrder(int orderID, int pizzaID) => context.AddPizzaToOrder(orderID, pizzaID);

        public List<Pizza> GetAllPizzas() => context.GetAllPizzas();

        public Pizza GetPizzaByID(int pizzaID) => context.GetPizzaByID(pizzaID);

        public List<Product> GetPizzasByOrder(int orderID) => context.GetPizzasByOrder(orderID);
    }
}
