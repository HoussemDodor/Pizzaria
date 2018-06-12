using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Side : Product
    {
        public int ID { get; set; }
        public decimal BuyInPrice { get; set; }
        public decimal SidePrice { get; set; }
        public string SideName { get; set; }
        public bool Vegan { get; set; }
        public bool Halal { get; set; }
        public bool Alcohol { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        internal override decimal GetPrice()
        {
            return SidePrice / 100;
        }

        public override string ToString()
        {
            return $"{SideName}";
        }
    }
}
