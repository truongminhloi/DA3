using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Service.Contract;
using DA3.Service.Dto;
using DA3.Service.Request;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger; 

        public ProductService(IMapper mapper, IApplicationDbContext dbContext, ILogger<ProductDto> logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<ProductDto>> All()
        {
            var productEntitys = _dbContext.Products.ToList();

            return _mapper.Map<List<Product>, List<ProductDto>>(productEntitys);
        }

        public async Task<bool> Create(CreateProductRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var productEntity = _mapper.Map<CreateProductRequest, Product>(request);

                await _dbContext.Products.AddAsync(productEntity, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> Update(UpdateProductRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var productEntity = _mapper.Map<UpdateProductRequest, Product>(request);

                _dbContext.Products.Update(productEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(int productId, CancellationToken cancellationToken = default)
        {
            try
            {
                var productEntity = _dbContext.Products.ProjectTo<Product>(_mapper.ConfigurationProvider).FirstOrDefault(x=>x.Id == productId);
                productEntity.Status = Common.Status.DELETE;

                _dbContext.Products.Update(productEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<ProductDto> FindById(int productId)
        {
            var productEntity = _dbContext.Products.ProjectTo<Product>(_mapper.ConfigurationProvider).FirstOrDefault(x => x.Id == productId);
            return _mapper.Map<Product, ProductDto>(productEntity);
        }
    }
}
