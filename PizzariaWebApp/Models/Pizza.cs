using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Pizza : Product
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [ScaffoldColumn(false)]
        public int DoughID { get; set; }
        [ScaffoldColumn(false)]
        public int ShapeID { get; set; }
        [Display(Name = "Lengte")]
        public int Length { get; set; }
        [Display(Name = "Breedte")]
        public int Width { get; set; }
        [Display(Name = "Lengte van 3de zijde")]
        public int SideLength { get; set; }
        [ScaffoldColumn(false)]
        public bool StandardPizza { get; set; }
        [Display(Name = "Topping")]
        public List<Topping> ToppingsList { get; set; }
        [Display(Name = "Vorm")]
        public Shape Shape { get; set; }
        [Display(Name = "Deeg")]
        public DoughType DoughType { get; set; }

        public int GetSize(int length, int width, int sideLength)
        {
            if (ShapeID == 1)
            {
                Circle c = new Circle();
                return c.GetSize(length, width, sideLength);
            }
            else if (ShapeID == 2)
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

        public override decimal GetPrice()
        {
            decimal price= 0;
            decimal area = (decimal)GetSize(Length, Width, SideLength);

            // bereken de prijs voor alle toppings
            foreach (Topping topping in ToppingsList)
            {
                price += topping.price * area;
            }

            // prijs berekenen voor de Dough
            price += area * DoughType.price;

            // als het een standaard pizza is geld er een 25% korting
            if (StandardPizza)
            {
                price = price * (decimal)0.75;
            }

            return price;
        }

        public override string ToString()
        {
            string topping = "";

            foreach(var x in ToppingsList)
            { 
                topping += $" {x.name}";
            }
            return $"{Shape.name} {DoughType.name} {topping}";
        }
    }
}
