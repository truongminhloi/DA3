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
    public class ProductService : IProductService
    {
        private readonly ICommonService _commonService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public ProductService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger, ICategoryService categoryService)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
            _categoryService = categoryService;
        }

        public List<ProductModel> GetAllProducts()
        {
            try
            {
                var allProductEntitys = _dbContext.Products.AsNoTracking().Where(x=>x.Status != Status.DELETE).ToList() ?? new List<Product>();
                var allProducts = _mapper.Map<List<Product>, List<ProductModel>>(allProductEntitys);
                foreach (var item in allProducts)
                {
                    item.CategoryName = _categoryService.GetCategoryById(item.CategoryId)?.Name;
                }
                return allProducts;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ProductModel GetProductById(string productId)
        {
            try
            {
                var productEntity = _dbContext.Products.AsNoTracking().FirstOrDefault(x => x.Id == new Guid(productId)) ?? new Product();
                var product = _mapper.Map<Product, ProductModel>(productEntity);

                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Create(ProductModel model)
        {
            try
            {
                var entity = _mapper.Map<ProductModel, Product>(model);
                _dbContext.Products.AddAsync(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(ProductModel model)
        {
            try
            {
                var entity = _mapper.Map<ProductModel, Product>(model);
                _dbContext.Products.Update(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
