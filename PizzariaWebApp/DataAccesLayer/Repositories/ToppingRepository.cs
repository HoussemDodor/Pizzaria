using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class ToppingRepository
    {
        private ITopping context;

        public ToppingRepository()
        {
            context = new ToppingSQLContext();
        }

        public List<Topping> GetAllToppings()
        {
            return context.GetAllToppings();
        }

        public Topping GetToppingByID(int toppingID)
        {
            return context.GetToppingByID(toppingID);
        }
    }
}
