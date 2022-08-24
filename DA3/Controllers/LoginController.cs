using DA3.Service.Contract;
using DA3.Service.Request;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class LoginController : Controller
    {
        //private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            //_loginService = loginService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //[Route("login")]
        //public async Task<bool> Login (LoginRequest request)
        //{
        //    return await _loginService.Login(request);
        //}
    }
}
