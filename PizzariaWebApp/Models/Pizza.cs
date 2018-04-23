using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pizza : Product
    {
        public int ID { get; set; }
        public int doughID { get; set; }
        public int shapeID { get; set; }
        public int length { get; set; }
        public int width { get; set; }
        public int sideLength { get; set; }
        public bool standardPizza { get; set; }
        List<Topping> toppingsList { get; set; }
        Shape shape { get; set; }
        DoughType doughType { get; set; }


        public Pizza(int id, string name, int doughID, int shapeID, int length, int width, int sideLength, bool standardPizza)
        {
            this.ID = id;
            this.name = name;
            this.doughID = doughID;
            this.shapeID = shapeID;
            this.length = length;
            this.width = width;
            this.sideLength = sideLength;
            this.standardPizza = standardPizza;
        }
        public Pizza(string name, int doughID, int shapeID, int length, int width, int sideLength, bool standardPizza)
        {
            this.name = name;
            this.doughID = doughID;
            this.shapeID = shapeID;
            this.length = length;
            this.width = width;
            this.sideLength = sideLength;
            this.standardPizza = standardPizza;         
        }

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
    }
}
