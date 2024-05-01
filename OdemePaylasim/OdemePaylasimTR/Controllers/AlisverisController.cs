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
    public class AlisverisController : Controller
    {
        private readonly OdemePaylasimDbContext _context;

        public AlisverisController(OdemePaylasimDbContext context)
        {
            _context = context;
        }

        // GET: Alisveris
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlisverisAddEditViewModel.ToListAsync());
        }

        // GET: Alisveris/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisverisAddEditViewModel = await _context.AlisverisAddEditViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alisverisAddEditViewModel == null)
            {
                return NotFound();
            }

            return View(alisverisAddEditViewModel);
        }

        // GET: Alisveris/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alisveris/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Tutar,IsActive")] AlisverisAddEditViewModel alisverisAddEditViewModel)
        {
			Alisveris alisveris = new Alisveris();
			alisveris.Ad = alisverisAddEditViewModel.Ad;
            alisveris.Tutar = alisverisAddEditViewModel.Tutar;
            alisveris.IsActive = alisverisAddEditViewModel.IsActive;
            alisveris.CreatedDate = DateTime.Now;

			if (ModelState.IsValid)
            {
                _context.Add(alisveris);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alisverisAddEditViewModel);
        }

        // GET: Alisveris/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisverisAddEditViewModel = await _context.AlisverisAddEditViewModel.FindAsync(id);
            if (alisverisAddEditViewModel == null)
            {
                return NotFound();
            }
            return View(alisverisAddEditViewModel);
        }

        // POST: Alisveris/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Tutar,IsActive")] AlisverisAddEditViewModel alisverisAddEditViewModel)
        {
            if (id != alisverisAddEditViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alisverisAddEditViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlisverisAddEditViewModelExists(alisverisAddEditViewModel.Id))
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
            return View(alisverisAddEditViewModel);
        }

        // GET: Alisveris/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alisverisAddEditViewModel = await _context.AlisverisAddEditViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alisverisAddEditViewModel == null)
            {
                return NotFound();
            }

            return View(alisverisAddEditViewModel);
        }

        // POST: Alisveris/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alisverisAddEditViewModel = await _context.AlisverisAddEditViewModel.FindAsync(id);
            if (alisverisAddEditViewModel != null)
            {
                _context.AlisverisAddEditViewModel.Remove(alisverisAddEditViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlisverisAddEditViewModelExists(int id)
        {
            return _context.AlisverisAddEditViewModel.Any(e => e.Id == id);
        }
    }
}
