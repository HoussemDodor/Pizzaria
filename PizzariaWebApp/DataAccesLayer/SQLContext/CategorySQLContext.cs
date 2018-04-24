using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    internal class CategorySQLContext : ICategory
    {
        public List<Category> GetAllCategory()
        {
            throw new NotImplementedException();
        }

        public Category GetCategoryByID(int categoryID)
        {
            throw new NotImplementedException();
        }
    }
}
