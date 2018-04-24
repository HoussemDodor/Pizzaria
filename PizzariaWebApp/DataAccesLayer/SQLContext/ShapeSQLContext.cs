using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class ShapeSQLContext : IShape
    {
        public List<Shape> GetAllShapes()
        {
            throw new NotImplementedException();
        }

        public Shape GetShapeByID(int shapeID)
        {
            throw new NotImplementedException();
        }
    }
}
