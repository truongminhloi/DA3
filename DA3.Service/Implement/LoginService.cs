using AutoMapper;
using AutoMapper.QueryableExtensions;
using DA3.DAL.Contract;
using DA3.DAL.Domain;
using DA3.Service.Contract;
using DA3.Service.Request;
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
        public async Task<bool> Login(LoginRequest request)
        {
            var pwdHashed = _commonService.GetHashedStringPwd(request.Password);
            var cheked =  _dbContext.Products.ProjectTo<Account>(_mapper.ConfigurationProvider)
                .Select(x => x.LoginId == request.LoginId && x.Password == pwdHashed);

            return cheked.FirstOrDefault();
        }
    }
}
