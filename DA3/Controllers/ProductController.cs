using DA3.Common;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DA3.Controler
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISession _session;
        public ProductController(IProductService productService, ISession session, ICategoryService categoryService)
        {
            _productService = productService;
            _session = session;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var allProducts = _productService.GetAllProducts();
            var productViewModel = new ProductViewModel
            {
                Products = allProducts
            };
            return View(productViewModel);
        }

        public IActionResult Admin()
        {
            var allProducts = _productService.GetAllProducts();
            var viewModel = new ProductViewModel
            {
                Products = allProducts
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var categoryModels = _categoryService.GetAllCategories();
            var model = new ProductModel();
            model.CategoryModels = categoryModels;
            return View(model);
        }

        public IActionResult HandelCreate(ProductModel model)
        {
            model.Status = Status.ACTIVE;
            _productService.Create(model);
            return RedirectToAction("Admin", "Product");
        }

        public IActionResult HandelEdit(ProductModel model)
        {
            model.Status = Status.ACTIVE;
            _productService.Update(model);
            return RedirectToAction("Admin", "Product");
        }
        public IActionResult Edit(string productId)
        {
            var model = _productService.GetProductById(productId);
            var categoryModels = _categoryService.GetAllCategories();
            model.CategoryModels = categoryModels;
            return View(model);
        }

        public IActionResult Remove(string productId)
        {
            var model = _productService.GetProductById(productId);
            model.Status = Status.DELETE;
            _productService.Update(model);
            return RedirectToAction("Admin", "Product");
        }

    }
}
