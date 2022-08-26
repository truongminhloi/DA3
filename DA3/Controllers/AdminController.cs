using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class AdminController : Controller
    {


        public AdminController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
