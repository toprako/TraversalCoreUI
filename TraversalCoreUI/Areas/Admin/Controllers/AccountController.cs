using BusinessLayer.Abstract.AbstractUow;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreUI.Areas.Admin.Models;

namespace TraversalCoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var SenderAccount = _accountService.GetById(model.SenderId);
            var ReceiverAccount = _accountService.GetById(model.ReceiverId);
            SenderAccount.Balance -= model.Amount;
            ReceiverAccount.Balance += model.Amount;
            List<Account> modifiedAccounts = new()
            {
                SenderAccount, ReceiverAccount
            };
            _accountService.TMultiUpdate(modifiedAccounts);
            return View();
        }
    }
}
