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
            
            return 1;
        }
    }
}
