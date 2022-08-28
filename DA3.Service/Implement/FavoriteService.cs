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
    public class FavoriteService : IFavoriteService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public FavoriteService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Favorite> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<FavoriteModel> GetAllFavorites()
        {
            try
            {
                var entitys = _dbContext.Favorites.AsNoTracking().ToList() ?? new List<Favorite>();
                var models = _mapper.Map<List<Favorite>, List<FavoriteModel>>(entitys);

                return models;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string SaveChange(FavoriteModel model)
        {
            try
            {
                var entity = _mapper.Map<FavoriteModel, Favorite>(model);
                _dbContext.Favorites.Add(entity);
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
