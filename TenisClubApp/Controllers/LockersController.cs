using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TC.DomainModels;
using TC.DomainModels.Models;

namespace TC.MVC.Controllers
{
    public class LockersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LockersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lockers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lockers.ToListAsync());
        }

        // GET: Lockers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locker = await _context.Lockers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locker == null)
            {
                return NotFound();
            }

            return View(locker);
        }

        // GET: Lockers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lockers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberId,RentedFrom,RentedUntil,IsDeleted,DateDeleted,DeletedBy,DateCreated,CreatedBy,LastModified,ModifiedBy,Id")] Locker locker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locker);
        }

        // GET: Lockers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locker = await _context.Lockers.FindAsync(id);
            if (locker == null)
            {
                return NotFound();
            }
            return View(locker);
        }

        // POST: Lockers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MemberId,RentedFrom,RentedUntil,IsDeleted,DateDeleted,DeletedBy,DateCreated,CreatedBy,LastModified,ModifiedBy,Id")] Locker locker)
        {
            if (id != locker.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LockerExists(locker.Id))
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
            return View(locker);
        }

        // GET: Lockers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locker = await _context.Lockers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locker == null)
            {
                return NotFound();
            }

            return View(locker);
        }

        // POST: Lockers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var locker = await _context.Lockers.FindAsync(id);
            _context.Lockers.Remove(locker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LockerExists(long id)
        {
            return _context.Lockers.Any(e => e.Id == id);
        }
    }
}
