using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rectangle : Shape
    {
        public override int GetSize(int length, int width, int sideLength)
        {
            int area = length * width;
            return area;
        }
    }
}
