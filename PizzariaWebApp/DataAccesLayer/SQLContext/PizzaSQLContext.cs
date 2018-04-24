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

        public Pizza GetPizzaByID()
        {
            throw new NotImplementedException();
        }
    }
}
