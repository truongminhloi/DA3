using DA3.Common;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Admin()
        {
            var allCategories = _categoryService.AllCategories();
            var viewModel = new CategoryViewModel
            {
                Categories = allCategories
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string categoryId)
        {
            var categoryModel = _categoryService.GetCategoryById(categoryId);
            return View(categoryModel);
        }

        public IActionResult HandelCreate(CategoryModel categoryModel)
        {
            categoryModel.Status = Status.ACTIVE;
            _categoryService.Create(categoryModel);
            return RedirectToAction("Admin", "Category");
        }

        public IActionResult HandelEdit(CategoryModel categoryModel)
        {
            _categoryService.Update(categoryModel);
            return RedirectToAction("Admin", "Category");
        }

        public IActionResult Remove(string categoryId)
        {
            var categoryModel = _categoryService.GetCategoryById(categoryId);
            categoryModel.Status = Status.DELETE;
            _categoryService.Update(categoryModel);
            return RedirectToAction("Index", "Category");
        }
    }
}
