﻿using DA3.Models;
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
            var model = _favoriteService.GetAllFavorites();

            return View(model);
        }

        public IActionResult HandelSaveChange(string productId)
        {
            var model = new FavoriteModel
            {
                ProductId = productId,
                UserId = _session.GetString("UserId")
            };

            _favoriteService.SaveChange(model);
            return RedirectToAction("Index", "Product");
        }

    }
}