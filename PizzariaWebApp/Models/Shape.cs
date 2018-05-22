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

        public abstract int GetSize(int length, int width, int sideLength);

        public abstract override string ToString();
    }
}
