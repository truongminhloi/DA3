using AutoMapper;
using DA3.Common;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DA3.Service.Implement
{
    public class AccountService : IAccountService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public AccountService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public List<AccountModel> GetAll()
        {
            try
            {
                var entities = _dbContext.Accounts.AsNoTracking().Where(x => x.Status != Status.DELETE).ToList() ?? new List<Account>();
                var models = _mapper.Map<List<Account>, List<AccountModel>>(entities);

                return models;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Create(AccountModel model)
        {
            try
            {
                //var pwdHashed = _commonService.GetHashedStringPwd(model.Password);
                model.Password = model.Password;
                model.Status = Status.ACTIVE;
                var entity = _mapper.Map<AccountModel, Account>(model);
                _dbContext.Accounts.AddAsync(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string Update(AccountModel model)
        {
            try
            {
                var entity = _mapper.Map<AccountModel, Account>(model);
                _dbContext.Accounts.Update(entity);
                _dbContext.SaveChanges();
                return entity.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public AccountModel GetById(string id)
        {
            try
            {
                var entity = _dbContext.Accounts.AsNoTracking().FirstOrDefault(x => x.Id == new Guid(id)) ?? new Account();
                var model = _mapper.Map<Account, AccountModel>(entity);

                return model;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
