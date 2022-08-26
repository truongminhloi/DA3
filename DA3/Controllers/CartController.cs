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
            var carModel = _cartService.GetcartByUserId("DA677218-E289-48D6-B686-782D7553DAC8");
            var cartViewModel = new CartViewModel
            {
                PriceShipFree = 20000,
                PriceShipStandard = 40000,
                PriceShipExpress = 60000,
                CartModel = carModel
            };
            return View(cartViewModel);
        }

        public IActionResult Create(string productId)
        {
            var productModel = _productService.GetProductById(productId);
            var carModel = _cartService.GetcartByUserId("1");
            if (GuidHelper.IsGuildNullOrEmpty(new Guid(carModel?.Id)))
            {
                var cartModel = new CartModel
                {
                    UserId = "DA677218-E289-48D6-B686-782D7553DAC8",
                    PricePerAllProducts = 1,
                    Address = "111 AA",
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
