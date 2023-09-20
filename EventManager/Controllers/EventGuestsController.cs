using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class EventGuestsController : Controller
    {
        private readonly AppDbContext _context;

        public EventGuestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EventGuests
        public async Task<IActionResult> Index()
        {
              return _context.EventGuests != null ? 
                          View(await _context.EventGuests.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.EventGuests'  is null.");
        }

        // GET: EventGuests/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.EventGuests == null)
            {
                return NotFound();
            }

            var eventGuest = await _context.EventGuests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventGuest == null)
            {
                return NotFound();
            }

            return View(eventGuest);
        }

        // GET: EventGuests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EventGuests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Address,MobileNo1,MobileNo2,Email,CreatedDate,LastUpdatedDate")] EventGuest eventGuest)
        {
            if (ModelState.IsValid)
            {
                eventGuest.Id = Guid.NewGuid();
                _context.Add(eventGuest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventGuest);
        }

        // GET: EventGuests/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.EventGuests == null)
            {
                return NotFound();
            }

            var eventGuest = await _context.EventGuests.FindAsync(id);
            if (eventGuest == null)
            {
                return NotFound();
            }
            return View(eventGuest);
        }

        // POST: EventGuests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Address,MobileNo1,MobileNo2,Email,CreatedDate,LastUpdatedDate")] EventGuest eventGuest)
        {
            if (id != eventGuest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventGuest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventGuestExists(eventGuest.Id))
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
            return View(eventGuest);
        }

        // GET: EventGuests/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.EventGuests == null)
            {
                return NotFound();
            }

            var eventGuest = await _context.EventGuests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventGuest == null)
            {
                return NotFound();
            }

            return View(eventGuest);
        }

        // POST: EventGuests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.EventGuests == null)
            {
                return Problem("Entity set 'AppDbContext.EventGuests'  is null.");
            }
            var eventGuest = await _context.EventGuests.FindAsync(id);
            if (eventGuest != null)
            {
                _context.EventGuests.Remove(eventGuest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventGuestExists(Guid id)
        {
          return (_context.EventGuests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
