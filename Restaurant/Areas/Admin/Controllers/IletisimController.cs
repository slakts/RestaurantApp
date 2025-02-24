using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant.Models;
using Restaurant.Models.Entities;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class IletisimController : Controller
    {
        private readonly VeriTabaniContext _context;

        public IletisimController(VeriTabaniContext context)
        {
            _context = context;
        }

        // GET: Admin/Iletisim
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iletisimler.ToListAsync());
        }

        // GET: Admin/Iletisim/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisimler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // GET: Admin/Iletisim/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Iletisim/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Telefon,Adres")] Iletisim iletisim)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iletisim);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: Admin/Iletisim/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisimler.FindAsync(id);
            if (iletisim == null)
            {
                return NotFound();
            }
            return View(iletisim);
        }

        // POST: Admin/Iletisim/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Telefon,Adres")] Iletisim iletisim)
        {
            if (id != iletisim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iletisim);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IletisimExists(iletisim.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iletisim);
        }

        // GET: Admin/Iletisim/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iletisim = await _context.Iletisimler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iletisim == null)
            {
                return NotFound();
            }

            return View(iletisim);
        }

        // POST: Admin/Iletisim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iletisim = await _context.Iletisimler.FindAsync(id);
            if (iletisim != null)
            {
                _context.Iletisimler.Remove(iletisim);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IletisimExists(int id)
        {
            return _context.Iletisimler.Any(e => e.Id == id);
        }
    }
}
