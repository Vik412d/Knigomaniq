using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Knigomaniq.Data;
using Knigomaniq.Models;

namespace Knigomaniq.Controllers
{
    public class PrintHousesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrintHousesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrintHouses
        public async Task<IActionResult> Index()
        {
              return View(await _context.PrintHouse.ToListAsync());
        }

        // GET: PrintHouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrintHouse == null)
            {
                return NotFound();
            }

            var printHouse = await _context.PrintHouse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printHouse == null)
            {
                return NotFound();
            }

            return View(printHouse);
        }

        // GET: PrintHouses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrintHouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PrintHouse printHouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(printHouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(printHouse);
        }

        // GET: PrintHouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrintHouse == null)
            {
                return NotFound();
            }

            var printHouse = await _context.PrintHouse.FindAsync(id);
            if (printHouse == null)
            {
                return NotFound();
            }
            return View(printHouse);
        }

        // POST: PrintHouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PrintHouse printHouse)
        {
            if (id != printHouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(printHouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrintHouseExists(printHouse.Id))
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
            return View(printHouse);
        }

        // GET: PrintHouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrintHouse == null)
            {
                return NotFound();
            }

            var printHouse = await _context.PrintHouse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (printHouse == null)
            {
                return NotFound();
            }

            return View(printHouse);
        }

        // POST: PrintHouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PrintHouse == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrintHouse'  is null.");
            }
            var printHouse = await _context.PrintHouse.FindAsync(id);
            if (printHouse != null)
            {
                _context.PrintHouse.Remove(printHouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrintHouseExists(int id)
        {
          return _context.PrintHouse.Any(e => e.Id == id);
        }
    }
}
