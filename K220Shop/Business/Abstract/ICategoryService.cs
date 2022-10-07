using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        List<Category> GetActiveCategories();
    }
}