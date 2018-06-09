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
        public List<Topping> GetToppingByPizza(int PizzaID) => repo.GetToppingByPizza(PizzaID);
        public DoughType GetDoughType(int doughtTypeID) => repo.GetDoughType(doughtTypeID);
        public Shape GetShape(int shapeID) => repo.GetShape(shapeID);
    }
}
