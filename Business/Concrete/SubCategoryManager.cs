using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal _subcategoryDal;

        public SubCategoryManager(ISubCategoryDal subcategoryDal)
        {
            _subcategoryDal = subcategoryDal;
        }

        public void AddSubCategory(SubCategory subcategory)
        {
            _subcategoryDal.Add(subcategory);

        }

        public void DeleteSubCategory(SubCategory subcategory)
        {
            _subcategoryDal.Delete(subcategory);
        }

        public List<SubCategory> GetActiveSubCategories()
        {
            return _subcategoryDal.GetAll(x=> x.IsDeleted == false);
        }

        public List<SubCategory> GetAllSubCategories()
        {
            return _subcategoryDal.GetAll();
        }

        public SubCategory GetSubCategoryById(int id)
        {
            return _subcategoryDal.Get(x=>x.Id == id);
        }

        public void UpdateSubCategory(SubCategory subcategory)
        {
            _subcategoryDal.Update(subcategory);
        }
    }
}