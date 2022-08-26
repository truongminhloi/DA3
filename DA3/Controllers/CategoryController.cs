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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(CategoryModel categoryModel)
        {
            categoryModel.Status = Status.ACTIVE;
            _categoryService.Create(categoryModel);
            return RedirectToAction("Index", "Category");
        }
    }
}
