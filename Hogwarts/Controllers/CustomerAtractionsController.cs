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
    public class CustomerAtractionsController : Controller
    {
        private readonly HogwartsContext _context;

        public CustomerAtractionsController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: CustomerAtractions
        public async Task<IActionResult> Index()
        {
            var hogwartsContext = _context.CustomerAtractions.Include(c => c.Atractions).Include(c => c.Customer);
           
            return View(await hogwartsContext.ToListAsync());

         
        }

        // GET: CustomerAtractions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAtraction = await _context.CustomerAtractions
                .Include(c => c.Atractions)
                .Include(c => c.Customer)
                .SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customerAtraction == null)
            {
                return NotFound();
            }

            return View(customerAtraction);
        }

        // GET: CustomerAtractions/Create
        public IActionResult Create()
        {
            ViewData["AtractionId"] = new SelectList(_context.Atractions, "Id", "Id");
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id");
            return View();
        }

        // POST: CustomerAtractions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,AtractionId")] CustomerAtraction customerAtraction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerAtraction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AtractionId"] = new SelectList(_context.Atractions, "Id", "Id", customerAtraction.AtractionId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", customerAtraction.CustomerId);
            return View(customerAtraction);
        }

        // GET: CustomerAtractions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAtraction = await _context.CustomerAtractions.SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customerAtraction == null)
            {
                return NotFound();
            }
            ViewData["AtractionId"] = new SelectList(_context.Atractions, "Id", "Id", customerAtraction.AtractionId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", customerAtraction.CustomerId);
            return View(customerAtraction);
        }

        // POST: CustomerAtractions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerId,AtractionId")] CustomerAtraction customerAtraction)
        {
            if (id != customerAtraction.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerAtraction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerAtractionExists(customerAtraction.CustomerId))
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
            ViewData["AtractionId"] = new SelectList(_context.Atractions, "Id", "Id", customerAtraction.AtractionId);
            ViewData["CustomerId"] = new SelectList(_context.Customer, "Id", "Id", customerAtraction.CustomerId);
            return View(customerAtraction);
        }

        // GET: CustomerAtractions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerAtraction = await _context.CustomerAtractions
                .Include(c => c.Atractions)
                .Include(c => c.Customer)
                .SingleOrDefaultAsync(m => m.CustomerId == id);
            if (customerAtraction == null)
            {
                return NotFound();
            }

            return View(customerAtraction);
        }

        // POST: CustomerAtractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customerAtraction = await _context.CustomerAtractions.SingleOrDefaultAsync(m => m.CustomerId == id);
            _context.CustomerAtractions.Remove(customerAtraction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerAtractionExists(string id)
        {
            return _context.CustomerAtractions.Any(e => e.CustomerId == id);
        }
    }
}

