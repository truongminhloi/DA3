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
    public class FeedbackService : IFeedbackService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public FeedbackService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Favorite> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<FeedbackModel> GetAllFeedbacks()
        {
            try
            {
                var entitys = _dbContext.Feedbacks.AsNoTracking().ToList() ?? new List<Feedback>();
                var models = _mapper.Map<List<Feedback>, List<FeedbackModel>>(entitys);

                return models;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string SaveChange(FeedbackModel model)
        {
            try
            {
                var entity = _mapper.Map<FeedbackModel, Feedback>(model);
                _dbContext.Feedbacks.Add(entity);
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
