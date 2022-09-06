using DA3.Common;
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

        public IActionResult Admin()
        {
            var allOrders = _orderService.GetAllOrders();
            var dicStatusName = new Dictionary<int, string>()
            {
                {1, "Đang chờ xác nhận"},
                {2, "Đã xác nhận"},
                {3, "Đang giao hàng"},
                {4, "Đã giao hàng"},
                {5, "Đã từ chối"}
            };

            foreach (var item in allOrders)
            {
                var accountModel = _accountService.GetById(item.UserId);
                item.UserName = accountModel.FullName;
                item.StatusName = dicStatusName[(int)item.Status];
            };
            var viewModel = new OrderViewModel
            {
                OrderModels = allOrders
            };
            return View(viewModel);
        }


        public IActionResult User()
        {
            var allOrders = _orderService.GetAllOrders();
            var userId = _session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }
            var orderByUser = allOrders.Where(x => x.UserId == userId).ToList();
            var dicStatusName = new Dictionary<int, string>()
            {
                {1, "Đang chờ xác nhận"},
                {2, "Đã xác nhận"},
                {3, "Đang giao hàng"},
                {4, "Đã giao hàng"},
                {5, "Đã từ chối"}
            };

            foreach (var item in orderByUser)
            {
                var accountModel = _accountService.GetById(item.UserId);
                item.UserName = accountModel.FullName;
                item.StatusName = dicStatusName[(int)item.Status];
            };
            var viewModel = new OrderViewModel
            {
                OrderModels = orderByUser
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            var userId = _session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }
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
            carModel.PricePerAllProducts = (double)carModel.CartDetails.Sum(x => (double)x.PricePerProdcut);
            carModel.TotalPrice = 20000 + carModel.PricePerAllProducts;
            carModel.PriceShipping = 20000;
            var model = new CheckoutViewModel
            {
                AccountModel = accountModel,
                CartModel = carModel,
            };

            return View(model);
        }
        public IActionResult Edit(string orderId)
        {
            var model = _orderService.GetById(orderId);
            var accountModel = _accountService.GetById(model.UserId);
            model.UserName = accountModel.FullName;
            return View(model);
        }
        public IActionResult HandelCreate(CheckoutViewModel model)
        {
            var userId = _session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }
            var accountModel = _accountService.GetById(userId);
            var carModel = _cartService.GetcartByUserId(userId);
            var orderModel = new OrderModel
            {
                UserId = accountModel.Id,
                DeliveryDate = model.DeliveryDate,
                Note = model.Note,
                PayMethod = model.PayMethod,
                TotalPrice = carModel.TotalPrice,
                Status = StatusOrder.PENDING
            };
            var orderd = _orderService.Create(orderModel);
            foreach (var item in carModel.CartDetails)
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

            carModel.Status = Status.DELETE;
            _cartService.Update(carModel);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult HandelEdit(OrderModel model)
        {
            _orderService.Update(model);
            return RedirectToAction("Admin", "Checkout");
        }
    }
}
