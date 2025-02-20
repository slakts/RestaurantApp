using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.ViewComponents
{
    public class Iletisim : ViewComponent
    {
        private readonly VeriTabaniContext _db;
        public Iletisim(VeriTabaniContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var iletisim = _db.Iletisimler.ToList();
            return View(iletisim);
        }
    }
}
