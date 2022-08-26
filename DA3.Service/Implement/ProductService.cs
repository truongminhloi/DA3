using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.Common;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class ProductService : IProductService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<ProductModel> AllProducts()
        {
            try
            {
                var allProductEntitys = _dbContext.Products.ToList() ?? new List<Product>();
                var allProducts = _mapper.Map<List<Product>, List<ProductModel>>(allProductEntitys);

                return allProducts;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ProductModel GetProductById(string productId)
        {
            try
            {
                var productEntity = _dbContext.Products.FirstOrDefault(x => x.Id == new Guid(productId)) ?? new Product();
                var product = _mapper.Map<Product, ProductModel>(productEntity);

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
