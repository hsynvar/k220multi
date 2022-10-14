using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ISubCategoryService
    {
        void AddSubCategory(SubCategory subcategory);
        void DeleteSubCategory(SubCategory subcategory);
        void UpdateSubCategory(SubCategory subcategory);
        SubCategory GetSubCategoryById(int id);
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetActiveSubCategories();

    }
}