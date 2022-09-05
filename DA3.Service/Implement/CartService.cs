using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.Common;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class CartService : ICartService
    {
        private readonly ICommonService _commonService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public CartService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger, IProductService productService)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _productService = productService;
        }

        public List<CartModel> AllCarts()
        {
            try
            {
                var allCartEntitys = _dbContext.Carts.ToList() ?? new List<Cart>();
                var allCarts = _mapper.Map<List<Cart>, List<CartModel>>(allCartEntitys);

                return allCarts;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Create(CartModel cartModel)
        {
            try
            {
                var cartEntity = _mapper.Map<CartModel, Cart>(cartModel);
                _dbContext.Carts.AddAsync(cartEntity);
                _dbContext.SaveChanges();
                return cartEntity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CreateCartDetail(CartDetailModel cartDetailModel)
        {
            try
            {
                var cartDetailEntity = _mapper.Map<CartDetailModel, CartDetails>(cartDetailModel);
                _dbContext.CartDetails.AddAsync(cartDetailEntity);
                _dbContext.SaveChanges();
                return cartDetailEntity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(CartModel model)
        {
            try
            {
                var entity = _mapper.Map<CartModel, Cart>(model);
                _dbContext.Carts.Update(entity);
                _dbContext.SaveChanges();
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public CartModel GetcartByUserId(string userId)
        {
            try
            {
                var cartEntity = _dbContext.Carts.AsNoTracking().Where(x => x.UserId == userId && x.Status == Status.ACTIVE).FirstOrDefault() ?? new Cart();
                var cartDetails = _dbContext.CartDetails.AsNoTracking().Where(x => x.CartId == cartEntity.Id.ToString()).ToList();
                cartEntity.CartDetails = cartDetails;

                var carModel = _mapper.Map<Cart, CartModel>(cartEntity);
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
                return carModel;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
