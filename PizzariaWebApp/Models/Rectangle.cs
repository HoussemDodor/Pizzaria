using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rectangle : Shape
    {
        public Rectangle(int ID, string name) : base(ID, name)
        {
        }
        public Rectangle()
        {

        }

        public override int GetSize(int length, int width, int sideLength)
        {
            int area = length * width;
            return area;
        }
    }
}
