using ME.Application.WebApi.Data.Context;
using ME.Application.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ME.Application.WebApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }

        public IActionResult Index()
        {
            return View(_context.ApplicationUsers.Select(x=> new UserListModel { Id=x.Id, Name=x.Name, Surname=x.Surname }).ToList());
        }
    }
}
