using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class AboutController : Controller
    {


        public AboutController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
