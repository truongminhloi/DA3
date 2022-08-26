using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        public CartController(ICartService cartService, IProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string productId)
        {
            var productModel = _productService.GetProductById(productId);
            var cartModel = new CartModel
            {
                ProductId = productId
            };

            var action = _cartService.Create(cartModel);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(string Id)
        {
            return View();
        }
    }
}
