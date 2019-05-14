using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hogwarts.Models;

namespace Hogwarts.Controllers
{
    public class AtractionsController : Controller
    {
        private readonly HogwartsContext _context;

        public AtractionsController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: Atractions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atractions.ToListAsync());
        }

        // GET: Atractions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atractions = await _context.Atractions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (atractions == null)
            {
                return NotFound();
            }

            return View(atractions);
        }

        // GET: Atractions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Kind,State,Address,Age,Date,DurationTime")] Atractions atractions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atractions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atractions);
        }

        // GET: Atractions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atractions = await _context.Atractions.SingleOrDefaultAsync(m => m.Id == id);
            if (atractions == null)
            {
                return NotFound();
            }
            return View(atractions);
        }

        // POST: Atractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Kind,State,Address,Age,Date,DurationTime")] Atractions atractions)
        {
            if (id != atractions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atractions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtractionsExists(atractions.Id))
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
            return View(atractions);
        }

        // GET: Atractions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atractions = await _context.Atractions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (atractions == null)
            {
                return NotFound();
            }

            return View(atractions);
        }

        // POST: Atractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atractions = await _context.Atractions.SingleOrDefaultAsync(m => m.Id == id);
            _context.Atractions.Remove(atractions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtractionsExists(int id)
        {
            return _context.Atractions.Any(e => e.Id == id);
        }
    }
}
