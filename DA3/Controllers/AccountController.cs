using DA3.Common;
using DA3.Models;
using DA3.Service.Contract;
using Microsoft.AspNetCore.Mvc;

namespace DA3.Controler
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Admin()
        {
            var allAccounts = _accountService.GetAll();
            var viewModel = new AccountViewModel
            {
                Accounts = allAccounts
            };
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string accountId)
        {
            var model = _accountService.GetById(accountId);
            return View(model);
        }

        public IActionResult HandelCreate(AccountModel model)
        {
            model.Status = Status.ACTIVE;
            _accountService.Create(model);
            return RedirectToAction("Admin", "Account");
        }

        public IActionResult HandelEdit(AccountModel model)
        {
            model.Status = Status.ACTIVE;
            _accountService.Update(model);
            return RedirectToAction("Admin", "Account");
        }

        public IActionResult Remove(string accountId)
        {
            var model = _accountService.GetById(accountId);
            model.Status = Status.DELETE;
            _accountService.Update(model);
            return RedirectToAction("Admin", "Account");
        }
    }
}
