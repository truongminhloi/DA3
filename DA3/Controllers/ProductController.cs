using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class ProductController : Controller
    {


        public ProductController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
