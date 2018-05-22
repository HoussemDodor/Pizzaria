using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public int accountID { get; set; }
        public string deliveryAdress { get; set; }
        public string houseNumber { get; set; }
        public string houseNumberAddition { get; set; }
        public string city { get; set; }
        public DateTime dateOrderPlaced { get; set; }
        public string customerComment { get; set; }
        public bool takeAway { get; set; }
        public bool delivered { get; set; }
        List<Product> productsInThisOrder { get; set; }

        public override string ToString()
        {
            string i = "";
            foreach(var x in productsInThisOrder)
            {
                i += " " + x.ToString();
            }
            return i;
        }
    }
}
