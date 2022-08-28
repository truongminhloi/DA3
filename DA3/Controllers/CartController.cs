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
        private readonly ISession _session;
        public CartController(ICartService cartService, IProductService productService, ISession session)
        {
            _cartService = cartService;
            _productService = productService;
            _session = session;
        }

        public IActionResult Index()
        {
            var userId = _session.GetString("UserId");
            var carModel = _cartService.GetcartByUserId(userId);
            
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
            var userId = _session.GetString("UserId");
            var address = _session.GetString("Address");

            var productModel = _productService.GetProductById(productId);
            var carModel = _cartService.GetcartByUserId(address);
            if (GuidHelper.IsGuildNullOrEmpty(new Guid(carModel?.Id)))
            {
                var cartModel = new CartModel
                {
                    UserId = userId,
                    PricePerAllProducts = 1,
                    Address = address,
                    TotalPrice = 1000,
                    ShippingMethod = ShippingMethod.Freeshipping,
                    Status = Status.ACTIVE
                };
                var cartId = _cartService.Create(cartModel);

                var cartDetailModel = new CartDetailModel
                {
                    CartId = cartId,
                    ProductId = productId,
                    ProductName = productModel.Name,
                    PriceProduct = productModel.Price,
                    PricePerProdcut = productModel.Price * 1,
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
