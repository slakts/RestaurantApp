using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Restaurant.Models;
using Restaurant.Models.Entities;

namespace Restaurant.Areas.Customer.Controllers;

[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly VeriTabaniContext _db;
    private readonly IToastNotification _toast;
    public HomeController(ILogger<HomeController> logger, VeriTabaniContext db, IToastNotification toast)
    {
        _logger = logger;
        _db = db;
        _toast = toast;
    }

    public IActionResult Index()
    {
        var menu = _db.Menus.Where(i=> i.Ozel).ToList();
        return View(menu);
    }
    public IActionResult CategoryDetails(int? id)
    {
        var menu = _db.Menus.Where(i => i.CategoryId == id).ToList();
        ViewBag.KategoriId = id;
        return View(menu);
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Blog()
    {
        return View();
    }
    public IActionResult About()
    {
        var about = _db.Abouts.ToList();
        return View(about);
    }
    public IActionResult Gallery()
    {
        var gallery = _db.Galleries.ToList();
        return View(gallery);
    }
    public IActionResult Reservation()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reservation([Bind("Id,Name,Email,TelefonNo,Sayi,Saat,Tarih")] Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _db.Add(reservation);
            await _db.SaveChangesAsync();
            _toast.AddSuccessToastMessage("Teþekkür Ederiz Rezervasyon iþleminiz baþarýyla gerçekleþti...");
            return RedirectToAction(nameof(Index));
        }
        return View(reservation);
    }
    public IActionResult Menu()
    {
        var menu = _db.Menus.ToList();
        return View(menu);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
