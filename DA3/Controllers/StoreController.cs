using DA3.Common;
using DA3.Common.Enums;
using DA3.Common.Helper;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class StoreController : Controller
    {

        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IActionResult Admin()
        {
            var model = _storeService.GetStoreInfo();

            return View(model);
        }

        public IActionResult HandelSaveChange(StoreModel model)
        {
            _storeService.SaveChange(model);
            return RedirectToAction("Admin", "Store");
        }

    }
}
