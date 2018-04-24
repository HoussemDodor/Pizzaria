using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class ShapeRepository
    {
        private IShape context;

        public ShapeRepository()
        {
            context = new ShapeSQLContext();
        }

        public List<Shape> GetAllShapes()
        {
            return context.GetAllShapes();
        }

        public Shape GetShapeByID(int shapeID)
        {
            return context.GetShapeByID(shapeID);
        }
    }
}
