using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OdemePaylasimTR.Data;
using OdemePaylasimTR.Data.Entities;
using OdemePaylasimTR.Models;

namespace OdemePaylasimTR.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly OdemePaylasimDbContext _context;

        public KullaniciController(OdemePaylasimDbContext context)
        {
            _context = context;
        }

        // GET: Kullanici
        public async Task<IActionResult> Index()
        {
            return View(await _context.KullaniciAddEditViewModel.ToListAsync());
        }

        // GET: Kullanici/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullaniciAddEditViewModel = await _context.KullaniciAddEditViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciAddEditViewModel == null)
            {
                return NotFound();
            }

            return View(kullaniciAddEditViewModel);
        }

        // GET: Kullanici/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,Bakiye,IsActive")] KullaniciAddEditViewModel kullaniciAddEditViewModel)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(kullaniciAddEditViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullaniciAddEditViewModel);
        }

        // GET: Kullanici/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullaniciAddEditViewModel = await _context.KullaniciAddEditViewModel.FindAsync(id);
            if (kullaniciAddEditViewModel == null)
            {
                return NotFound();
            }
            return View(kullaniciAddEditViewModel);
        }

        // POST: Kullanici/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Bakiye,IsActive")] KullaniciAddEditViewModel kullaniciAddEditViewModel)
        {
            if (id != kullaniciAddEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullaniciAddEditViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciAddEditViewModelExists(kullaniciAddEditViewModel.Id))
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
            return View(kullaniciAddEditViewModel);
        }

        // GET: Kullanici/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullaniciAddEditViewModel = await _context.KullaniciAddEditViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciAddEditViewModel == null)
            {
                return NotFound();
            }

            return View(kullaniciAddEditViewModel);
        }

        // POST: Kullanici/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullaniciAddEditViewModel = await _context.KullaniciAddEditViewModel.FindAsync(id);
            if (kullaniciAddEditViewModel != null)
            {
                _context.KullaniciAddEditViewModel.Remove(kullaniciAddEditViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciAddEditViewModelExists(int id)
        {
            return _context.KullaniciAddEditViewModel.Any(e => e.Id == id);
        }
    }
}
