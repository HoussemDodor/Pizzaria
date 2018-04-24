using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface IShape
    {
        Shape GetShapeByID(int shapeID);
        List<Shape> GetAllShapes();
    }
}
