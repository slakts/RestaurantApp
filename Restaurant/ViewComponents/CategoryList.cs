using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.ViewComponents
{
    public class CategoryList:ViewComponent
    {
        private readonly VeriTabaniContext _db;
        public CategoryList(VeriTabaniContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var category = _db.Categories.ToList();
            return View(category);
        }

    }
}
