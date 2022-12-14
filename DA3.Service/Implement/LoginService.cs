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
    public class LoginService : ILoginService
    {
        private readonly ICommonService _commonService;
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _dbContext;
        private readonly ILogger _logger;

        public LoginService(ICommonService commonService, IApplicationDbContext dbContext,
            IMapper mapper, ILogger<Account> logger)
        {
            _commonService = commonService;
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Login(LoginModel loginModel)
        {
            //var pwdHashed = _commonService.GetHashedStringPwd(loginModel.Password);
            var user = _dbContext.Accounts.FirstOrDefault(x => x.PhoneNumber == loginModel.PhoneNumber && x.Password == loginModel.Password && x.Status == Status.ACTIVE);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool Register(LoginModel loginModel)
        {
            try
            {
                var accountEntity = _mapper.Map<LoginModel, Account>(loginModel);
                //var pwdHashed = _commonService.GetHashedStringPwd(loginModel.Password);
                accountEntity.Password = loginModel.Password;
                accountEntity.Status = Status.ACTIVE;

                _dbContext.Accounts.AddAsync(accountEntity);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
        public AccountModel GetAccountByPhoneNumber(string phoneNumber)
        {
            try
            {
                var accountEntity = _dbContext.Accounts.AsNoTracking().FirstOrDefault(x => x.PhoneNumber == phoneNumber) ?? new Account();
                var account = _mapper.Map<Account, AccountModel>(accountEntity);

                return account;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
