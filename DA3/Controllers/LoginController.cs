using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, ILoginService loginService)
        {
            _loginService = loginService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel loginModel)
        {
            var result = _loginService.Login(loginModel);
            if (result == true)
            {
                var account = _loginService.GetAccountByPhoneNumber(loginModel.PhoneNumber);
                HttpContext.Session.SetString("UserId", account?.Id);
                HttpContext.Session.SetString("PhoneNumber", account?.PhoneNumber);
                HttpContext.Session.SetString("FullName", account?.FullName);

                //var profileData = new UserProfileSessionData
                //{
                //    UserId = account.Id,
                //    PhoneNumber = account.PhoneNumber,
                //    Address = account.Address,
                //    FullName = account.FullName
                //};
                
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register(LoginModel loginModel)
        {
            var result = _loginService.Register(loginModel);
            return RedirectToAction("Index", "Home");
        }
    }
}
