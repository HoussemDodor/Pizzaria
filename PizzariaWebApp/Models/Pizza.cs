using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pizza : Product
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public int doughID { get; set; }
        [ScaffoldColumn(false)]
        public int shapeID { get; set; }
        [Display(Name = "Lengte")]
        public int length { get; set; }
        [Display(Name = "Breedte")]
        public int width { get; set; }
        [Display(Name = "Lengte van 3de zijde")]
        public int sideLength { get; set; }
        [ScaffoldColumn(false)]
        public bool standardPizza { get; set; }
        [Display(Name = "Topping")]
        List<Topping> toppingsList { get; set; }
        [Display(Name = "Vorm")]
        Shape shape { get; set; }
        [Display(Name = "Deeg")]
        DoughType doughType { get; set; }

        public int GetSize(int length, int width, int sideLength)
        {
            if (shapeID == 1)
            {
                Circle c = new Circle();
                return c.GetSize(length, width, sideLength);
            }
            else if (shapeID == 2)
            {
                Rectangle r = new Rectangle();
                return r.GetSize(length, width, sideLength);
            }
            else
            {
                Triangle t = new Triangle();
                return t.GetSize(length, width, sideLength);
            }
        }

        public decimal GetPrice()
        {
            decimal price= 0;
            decimal area = (decimal)GetSize(length, width, sideLength);

            // bereken de prijs voor alle toppings
            foreach (Topping topping in toppingsList)
            {
                price += topping.price * area;
            }

            // prijs berekenen voor de Dough
            price += area * doughType.price;

            // als het een standaard pizza is geld er een 25% korting
            if (standardPizza)
            {
                price = price * (decimal)0.75;
            }

            return price;
        }

        public override string ToString()
        {
            string topping = "";

            foreach(var x in toppingsList)
            { 
                topping += $" {x.name}";
            }
            return $"{shape.name} {doughType.name} {topping}";
        }
    }
}
