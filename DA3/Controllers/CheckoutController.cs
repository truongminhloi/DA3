using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class CheckoutController : Controller
    {

        private readonly ICartService _cartService;
        private readonly IProductService _productService;
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        private readonly ISession _session;
        public CheckoutController(ICartService cartService, IProductService productService, ISession session, IAccountService accountService, IOrderService orderService)
        {
            _cartService = cartService;
            _productService = productService;
            _session = session;
            _accountService = accountService;
            _orderService = orderService;
        }

        public IActionResult Create()
        {
            var userId = _session.GetString("UserId");
            var carModel = _cartService.GetcartByUserId(userId);
            var accountModel = _accountService.GetById(userId);
            foreach (var item in carModel.CartDetails)
            {
                var productModel = _productService.GetProductById(item.ProductId);
                item.ProductName = productModel.Name;
                item.PriceProduct = productModel.Price;
                item.PricePerProdcut = productModel.Price * item.Quantity;
                item.Url = productModel.Url;
            }
            carModel.PricePerAllProducts = (decimal)carModel.CartDetails.Sum(x => (double)x.PricePerProdcut);
            carModel.TotalPrice = 20000 + carModel.PricePerAllProducts;
            carModel.PriceShipping = 20000;
            var model = new CheckoutViewModel
            {
                AccountModel = accountModel,
                CartModel = carModel,
            };

            return View(model);
        }
        public IActionResult HandelCreate(CheckoutViewModel model)
        {
            var orderModel = new OrderModel
            {
                UserId = model.AccountModel.Id,
                DeliveryDate = model.DeliveryDate,
                Note = model.Note,
                PayMethod = model.PayMethod,
                TotalPrice = model.CartModel.TotalPrice
            };
            var orderd = _orderService.Create(orderModel);
            foreach (var item in model.CartModel.CartDetails)
            {
                var orderDetailModel = new OrderDetailModel
                {
                    OrderId = orderd,
                    ProductId = item.ProductId,
                    Price = item.PriceProduct,
                    Quantity = item.Quantity
                };
                _orderService.CreateOrderDetail(orderDetailModel);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
