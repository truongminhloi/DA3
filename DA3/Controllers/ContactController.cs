using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class ContactController : Controller
    {


        public ContactController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
