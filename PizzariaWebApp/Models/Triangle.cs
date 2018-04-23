using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Triangle : Shape
    {
        public Triangle(int ID, string name) : base(ID, name)
        {
        }
        public Triangle()
        {

        }

        public override int GetSize(int length, int width, int sideLength)
        {
            // De totaal van alle lengtes
            int sum = length + width + sideLength;

            // De som gedeeld door twee voor een tijdelijke variabele
            sum = sum / 2;

            // de lengtes aftrekken van de tijdelijke variabele
            int one = sum - length;
            int two = sum - width;
            int three = sum - sideLength;

            // alles met elkaar vermenigvuldigen
            sum = sum * length * width * sideLength;

            // de wortel pakken van het eind resultaat
            int area = Convert.ToInt32(Math.Sqrt(Convert.ToDouble(sum)));
            return area;
        }
    }
}
