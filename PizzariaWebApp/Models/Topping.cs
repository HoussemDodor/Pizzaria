using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Topping
    {
        public int ID { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public decimal buyInPrice { get; set; }
        public bool vegan { get; set; }
        public bool halal { get; set; }

        public Topping(string name, decimal price, decimal buyInPrice, bool vegan, bool halal)
        {
            this.name = name;
            this.price = price;
            this.buyInPrice = buyInPrice;
            this.vegan = vegan;
            this.halal = halal;
        }
        public Topping(int ID, string name, decimal price, decimal buyInPrice, bool vegan, bool halal)
        {
            this.ID = ID;
            this.name = name;
            this.price = price;
            this.buyInPrice = buyInPrice;
            this.vegan = vegan;
            this.halal = halal;
        }
    }
}
