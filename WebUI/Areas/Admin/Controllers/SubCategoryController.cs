using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class SubCategoryController : Controller
    {

        private readonly ISubCategoryService _subcategoryservice;

        public SubCategoryController(ISubCategoryService subcategoryservice)
        {
            _subcategoryservice = subcategoryservice;
        }

        public IActionResult Index()
        {
            var subcategories = _subcategoryservice.GetActiveSubCategories();
            return View(subcategories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SubCategory category)
        {
            _subcategoryservice.AddSubCategory(category);
            return RedirectToAction(nameof(Index));

        }

         [HttpGet]
        public IActionResult Edit(int id)
        {
            var subcategory = _subcategoryservice.GetSubCategoryById(id);
            return View(subcategory);
        }

        [HttpPost]
        public IActionResult Edit( SubCategory subcategory)
        {
            _subcategoryservice.UpdateSubCategory(subcategory);
            return RedirectToAction("Index");
        }

          [HttpGet]
        public IActionResult Delete( int id )
        {
            var subcategory = _subcategoryservice.GetSubCategoryById(id);
            return View(subcategory);
        }

        [HttpPost]

        public IActionResult Delete( SubCategory subcategory)
        {
            _subcategoryservice.DeleteSubCategory(subcategory);
            return RedirectToAction ("Index");

        }
       
    }
}