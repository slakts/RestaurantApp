using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
using Restaurant.Models.Entities;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly VeriTabaniContext _context;

        public AccountController(VeriTabaniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            var data = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Sifre == user.Sifre);
            if (data == null)
            {
                ViewBag.ErrorMessage = "Geçersiz e-posta veya şifre!";
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Menu", new { area = "Admin" });
            }
        }
    }
}
