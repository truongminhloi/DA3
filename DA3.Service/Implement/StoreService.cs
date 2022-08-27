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
    public class StoreService : IStoreService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public StoreService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public StoreModel GetStoreInfo()
        {
            try
            {
                var entity = _dbContext.Store.AsNoTracking().FirstOrDefault() ?? new Store();
                var model = _mapper.Map<Store, StoreModel>(entity);

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string SaveChange(StoreModel model)
        {
            try
            {
                var entity = _mapper.Map<StoreModel, Store>(model);
                var entityDb = _dbContext.Store.AsNoTracking().FirstOrDefault();
                if (entityDb != null)
                {
                    _dbContext.Store.Update(entity);
                }
                else
                {
                    _dbContext.Store.Add(entity);
                }
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
