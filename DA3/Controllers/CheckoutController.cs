using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class CheckoutController : Controller
    {


        public CheckoutController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
