using DA3.Models;
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
            var storeModel = _storeService.GetStoreInfo() ?? new StoreModel();
            var model = new ContactViewModel
            {
                StoreModel = storeModel,
                FeedbackModel = new FeedbackModel()
            };
            return View(model);
        }
    }
}
