using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DataAccesLayer;

namespace LogicLayer
{
    public class ProductLogic
    {
        private SidesRepository sideRepo;
        private PizzaRepository pizzaRepo;

        public ProductLogic()
        {
            sideRepo = new SidesRepository();
            pizzaRepo = new PizzaRepository();
        }

        public List<Side> GetAllSides() => sideRepo.GetAllSides();

        public Side GetSideByID(int sideID) => sideRepo.GetSideByID(sideID);

        public List<Side> GetSideByCategory(int categoryID) => sideRepo.GetSideByCategory(categoryID);

        public void AddPizzaToOrder(int orderID, int pizzaID) => pizzaRepo.AddPizzaToOrder(orderID, pizzaID);

        public List<Pizza> GetAllPizzas() => pizzaRepo.GetAllPizzas();

        public Pizza GetPizzaByID(int pizzaID) => pizzaRepo.GetPizzaByID(pizzaID);
    }
}
