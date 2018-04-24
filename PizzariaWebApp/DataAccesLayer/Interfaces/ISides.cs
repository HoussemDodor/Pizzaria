using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal interface ISides
    {
        List<Side> GetAllSides();
        Side GetSideByID(int sideID);
        Category GetCategoryBySide(int categoryID);
    }
}
