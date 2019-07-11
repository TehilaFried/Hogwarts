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
    public class SignUpApplicationsController : Controller
    {
        private readonly HogwartsContext _context;

        public SignUpApplicationsController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: SignUpApplications
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignUpApplication.ToListAsync());
        }

        // GET: SignUpApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpApplication = await _context.SignUpApplication
                .SingleOrDefaultAsync(m => m.Id == id);
            if (signUpApplication == null)
            {
                return NotFound();
            }

            return View(signUpApplication);
        }

        // GET: SignUpApplications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignUpApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CheckIn,CheckOut")] SignUpApplication signUpApplication)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(signUpApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signUpApplication);
        }

        // GET: SignUpApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpApplication = await _context.SignUpApplication.SingleOrDefaultAsync(m => m.Id == id);
            if (signUpApplication == null)
            {
                return NotFound();
            }
            return View(signUpApplication);
        }

        // POST: SignUpApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CheckIn,CheckOut")] SignUpApplication signUpApplication)
        {
            if (id != signUpApplication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signUpApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignUpApplicationExists(signUpApplication.Id))
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
            return View(signUpApplication);
        }

        // GET: SignUpApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signUpApplication = await _context.SignUpApplication
                .SingleOrDefaultAsync(m => m.Id == id);
            if (signUpApplication == null)
            {
                return NotFound();
            }

            return View(signUpApplication);
        }

        // POST: SignUpApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signUpApplication = await _context.SignUpApplication.SingleOrDefaultAsync(m => m.Id == id);
            _context.SignUpApplication.Remove(signUpApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignUpApplicationExists(int id)
        {
            return _context.SignUpApplication.Any(e => e.Id == id);
        }
    }
}
