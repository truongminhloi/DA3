using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Models;
using DA3.Service.Contract;
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
            var pwdHashed = _commonService.GetHashedStringPwd(loginModel.Password);
            var cheked = _dbContext.Accounts.ProjectTo<Account>(_mapper.ConfigurationProvider)
                .Select(x => x.LoginId == loginModel.PhoneNumber && x.Password == pwdHashed);

            return cheked.FirstOrDefault();
        }

        public bool Register(LoginModel loginModel)
        {
            try
            {
                var accountEntity = _mapper.Map<LoginModel, Account>(loginModel);

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
    }
}
