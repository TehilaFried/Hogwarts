﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hogwarts.Models;

namespace Hogwarts.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HogwartsContext _context;
        private const string IsAdminKey = "isAdmin";
        private const string CustomerKey = "customer";
        private const string CustomerIdKey = "customerId";

        public OrdersController(HogwartsContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumOfTickets,TotalCost,Time")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            if (orders == null)
            {
                return NotFound();
            }
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumOfTickets,TotalCost,Time")] Orders orders)
        {
            if (id != orders.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.Id))
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
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(CustomerKey)) && !string.IsNullOrEmpty(HttpContext.Session.GetString(IsAdminKey)))
            {
                if (id == null)
                {
                    return NotFound();
                }

                var orders = await _context.Orders
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (orders == null)
                {
                    return NotFound();
                }

                return View(orders);
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.SingleOrDefaultAsync(m => m.Id == id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }

        public async Task<IActionResult> AddToCart(Atractions attraction)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(CustomerKey)))
            {
                var order = await _context.Orders
                    .SingleOrDefaultAsync(m => m.Atractions.Id == attraction.Id);
                var att = await _context.Atractions
                    .SingleOrDefaultAsync(m => m.Id == attraction.Id);


                if (order == null)
                {
                    Orders newOrder = new Orders();
                    newOrder.Atractions = att;
                    newOrder.NumOfTickets = 1;
                    newOrder.Time = DateTime.Now;
                    newOrder.TotalCost = att.TicketPrice;
                    _context.Add(newOrder);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    order.NumOfTickets++;
                    order.Time = DateTime.Now;
                    order.TotalCost += att.TicketPrice;
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            else;
            return RedirectToAction(nameof(Index));
        }
    }
}
