using DA3.Common;
using DA3.Common.Enums;
using DA3.Common.Helper;
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
            //var productModel = _productService.GetProductById();
            return View();
        }

        public IActionResult Create(string productId)
        {
            var productModel = _productService.GetProductById(productId);
            var carModel = _cartService.GetcartById("1");
            if (GuidHelper.IsGuildNullOrEmpty(new Guid(carModel?.Id)))
            {
                var cartModel = new CartModel
                {
                    UserId = "",
                    PricePerAllProducts = 1,
                    Address = "",
                    TotalPrice = 1000,
                    ShippingMethod = ShippingMethod.Freeshipping,
                    Status = Status.ACTIVE
                };
                var cartId = _cartService.Create(cartModel);

                var cartDetailModel = new CartDetailModel
                {
                    CartId = cartId,
                    ProductId = productId,
                    Quantity = 1,
                    Status = Status.ACTIVE
                };
                var cartDetailId = _cartService.CreateCartDetail(cartDetailModel);
            }
            else
            {

            }
            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(string Id)
        {
            return View();
        }
    }
}
