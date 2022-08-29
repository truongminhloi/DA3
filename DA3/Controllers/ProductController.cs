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
            var userId = _session.GetString("UserId");
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

            IEnumerable<SelectListItem> items = categoryModels
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });
            ViewBag.CategoryID = items;
            return View();
        }
    }
}
