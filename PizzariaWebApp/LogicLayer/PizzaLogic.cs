using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer;
using Models;

namespace LogicLayer
{
    public class PizzaLogic
    {
        private PizzaRepository repo;

        public PizzaLogic()
        {
            repo = new PizzaRepository();
        }

        public List<Pizza> GetAllPizzas() => repo.GetAllPizzas();
        public Pizza GetPizzaByID(int pizzaID) => repo.GetPizzaByID(pizzaID);
    }
}
