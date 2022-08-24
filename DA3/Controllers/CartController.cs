using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class CartController : Controller
    {


        public CartController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
