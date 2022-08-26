using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISession _session;
        public ProductController(IProductService productService, ISession session)
        {
            _productService = productService;
            _session = session;
        }

        public IActionResult Index()
        {
            var userId = _session.GetString("UserId");
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
