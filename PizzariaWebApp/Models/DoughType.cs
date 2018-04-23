using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DoughType
    {
        public int ID { get; set; }
        public string doughType { get; set; }
        public decimal price { get; set; }
        public decimal buyInPrice { get; set; }

        public DoughType(int ID, string doughType, decimal price, decimal buyInPrice)
        {
            this.ID = ID;
            this.doughType = doughType;
            this.price = price;
            this.buyInPrice = buyInPrice;
        }
        public DoughType(string doughType, decimal price, decimal buyInPrice)
        {
            this.doughType = doughType;
            this.price = price;
            this.buyInPrice = buyInPrice;
        }
    }
}
