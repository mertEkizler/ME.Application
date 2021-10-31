using ME.Application.WebApi.Data.Context;
using ME.Application.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ME.Application.WebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationContext _context;

        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult Create(int id)
        {
            var userInfo = _context.ApplicationUsers.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname

            }).SingleOrDefault(x => x.Id == id);

            return View(userInfo);
        }

        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _context.Accounts.Add(new Data.Entities.Account
            {
                AccountNumber = model.AccountNumber,
                ApplicationUserId = model.ApplicationUserId,
                Balance = model.Balance
            });
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
