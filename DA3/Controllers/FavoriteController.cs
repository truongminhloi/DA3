using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class FavoriteController : Controller
    {

        private readonly IFavoriteService _favoriteService;
        private readonly ISession _session;
        public FavoriteController(IFavoriteService favoriteService, ISession session)
        {
            _favoriteService = favoriteService;
            _session = session;
        }

        public IActionResult Admin()
        {
            var favoriteModels = _favoriteService.GetAllFavorites();
            var model = new FavoriteViewModel
            {
                FavoriteModels = favoriteModels
            };
            return View(model);
        }

        public IActionResult HandelSaveChange(string productId)
        {
            var userId = _session.GetString("UserId");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Login");
            }

            var model = new FavoriteModel
            {
                ProductId = productId,
                UserId = userId
            };

            _favoriteService.SaveChange(model);
            return RedirectToAction("Index", "Product");
        }

    }
}
