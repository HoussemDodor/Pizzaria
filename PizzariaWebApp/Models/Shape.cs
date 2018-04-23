using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class Shape
    {
        public int ID { get; set; }
        public string name { get; set; }

        public Shape(int ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }
        public Shape()
        {

        }

        public abstract int GetSize(int length, int width, int sideLength);
    }
}
