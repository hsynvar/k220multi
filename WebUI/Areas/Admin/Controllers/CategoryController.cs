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


    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryservice;

        public CategoryController(ICategoryService categoryservice)
        {
            _categoryservice = categoryservice;
        }

        public IActionResult Index()
        {
            var categories = _categoryservice.GetActiveCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            _categoryservice.AddCategory(category);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryservice.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit( Category category)
        {
            _categoryservice.UpdateCategory(category);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete( int id )
        {
            var category = _categoryservice.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]

        public IActionResult Delete( Category category)
        {
            _categoryservice.DeleteCategory(category);
            return RedirectToAction ("Index");

        }


    }
}