using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var allProducts = _productService.AllProducts();
            var productViewModel = new ProductViewModel
            {
                Products = allProducts
            };
            return View(productViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
