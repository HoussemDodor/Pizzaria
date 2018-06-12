using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class ToppingRepository : ITopping
    {
        private ITopping context;

        public ToppingRepository()
        {
            context = new ToppingSQLContext();
        }

        public List<Topping> GetAllToppings() => context.GetAllToppings();

        public Topping GetToppingByID(int toppingID) => context.GetToppingByID(toppingID);

        public List<Topping> GetToppingsByPizza(int pizzaID) => context.GetToppingsByPizza(pizzaID);
    }
}
