using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Areas.Customer.Controllers;

[Area("Customer")]

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly VeriTabaniContext _db;
    public HomeController(ILogger<HomeController> logger, VeriTabaniContext db)
    {
        _logger = logger;
        _db = db;
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
        return View();
    }
    public IActionResult Gallery()
    {
        return View();
    }
    public IActionResult Reservation()
    {
        return View();
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
