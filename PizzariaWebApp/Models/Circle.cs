using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Circle : Shape
    {
        public override int GetSize(int length, int width, int sideLength)
        {
            double area;
            area = Math.Pow(length, 2) * Math.PI;
            area = area / 4;
            area = Math.Round(area);
            return (int)area;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
