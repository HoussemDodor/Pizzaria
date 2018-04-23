using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Circle : Shape
    {
        public Circle(int ID, string name) : base(ID, name)
        {

        }
        public Circle()
        {

        }

        public override int GetSize(int length, int width, int sideLength)
        {
            int area = Convert.ToInt32(Math.PI * Math.Pow(Convert.ToDouble(length), 2));
            return area;
        }
    }
}
