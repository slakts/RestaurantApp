using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.ViewComponents
{
    public class Yorumlar : ViewComponent
    {
        private readonly VeriTabaniContext _db;
        public Yorumlar(VeriTabaniContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var yorum = _db.Blogs.Where(i => i.Onay).ToList();
            return View(yorum);
        }
    }
}
