using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practica_MA.Data;
using Practica_MA.Models;

namespace Practica_MA.Controllers
{
    public class AutomobilsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutomobilsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Automobils
        public async Task<IActionResult> Index()
        {
            return View(await _context.Automobil.ToListAsync());
        }
        public async Task<IActionResult> Modele()
        {
            return View(await _context.Automobil.ToListAsync());
        }
        // GET: Automobils/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }
        public async Task<IActionResult> Automobil(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // GET: Automobils/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Automobils/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,details,marca,color,price")] Automobil automobil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(automobil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(automobil);
        }

        // GET: Automobils/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil.FindAsync(id);
            if (automobil == null)
            {
                return NotFound();
            }
            return View(automobil);
        }

        // POST: Automobils/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("id,name,details,marca,color,price")] Automobil automobil)
        {
            if (id != automobil.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(automobil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutomobilExists(automobil.id))
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
            return View(automobil);
        }

        // GET: Automobils/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var automobil = await _context.Automobil
                .FirstOrDefaultAsync(m => m.id == id);
            if (automobil == null)
            {
                return NotFound();
            }

            return View(automobil);
        }

        // POST: Automobils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var automobil = await _context.Automobil.FindAsync(id);
            _context.Automobil.Remove(automobil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutomobilExists(string id)
        {
            return _context.Automobil.Any(e => e.id == id);
        }
    }
}
