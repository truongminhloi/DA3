using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class ContactController : Controller
    {

        private readonly IStoreService _storeService;
        public ContactController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IActionResult Index()
        {
            var model = _storeService.GetStoreInfo();
            return View(model);
        }
    }
}
