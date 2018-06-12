using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        [Display(Name = "Klant")]
        public int CustomerID { get; set; }
        [Display(Name = "Bezorg adres")]
        public string deliveryAdress { get; set; }
        [Display(Name = "Huisnummer")]
        public string houseNumber { get; set; }
        [Display(Name = "Huisnummer Toevoegin")]
        public string houseNumberAddition { get; set; }
        [Display(Name = "Stad")]
        public string city { get; set; }
        [Display(Name = "Datum besteld")]
        public DateTime dateOrderPlaced { get; set; }
        [Display(Name = "Commentaar")]
        public string customerComment { get; set; }
        [Display(Name = "Ophalen")]
        public bool takeAway { get; set; }
        [Display(Name = "Bezorgd")]
        public bool Delivered { get; set; }
        public List<Product> productsInThisOrder { get; set; } = new List<Product>();
        [Display(Name = "Totaal prijs")]
        public decimal TotalPrice
        {
            get
            {
                decimal x = 0;
                foreach (var item in productsInThisOrder)
                {
                    x += item.Price;        
                }
                return x;
            }
        }
        [Display(Name = "Klant")]
        public Customer Customer { get; set; }

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
