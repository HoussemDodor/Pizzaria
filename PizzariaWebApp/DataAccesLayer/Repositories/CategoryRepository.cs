using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccesLayer
{
    public class CategoryRepository
    {
        private ICategory context;

        public CategoryRepository()
        {
            context = new CategorySQLContext();
        }

        public List<Category> GetAllCategory()
        {
            return context.GetAllCategory();
        }

        public Category GetCategoryByID(int categoryID)
        {
            return context.GetCategoryByID(categoryID);
        }
    }
}
