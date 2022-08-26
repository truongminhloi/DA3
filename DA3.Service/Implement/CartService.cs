using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class CartService : ICartService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public CartService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Create(CartModel cartModel)
        {
            try
            {
                var cartEntity = _mapper.Map<CartModel, Cart>(cartModel);
                _dbContext.Carts.AddAsync(cartEntity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool Delete(string Id)
        {
            try
            {
                var cartEntity = _dbContext.Accounts.ProjectTo<Account>(_mapper.ConfigurationProvider)
                    .FirstOrDefault(x => x.Id == new Guid(Id));
                _dbContext.Accounts.Remove(cartEntity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}
