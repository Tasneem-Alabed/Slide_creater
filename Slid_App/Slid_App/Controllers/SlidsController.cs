using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slid_App.Models;

namespace Slid_App.Controllers
{
    public class SlidsController : Controller
    {
        private readonly SlideAppDbContext _context;

        public SlidsController(SlideAppDbContext context)
        {
            _context = context;
        }

        // GET: Slids
        public async Task<IActionResult> Index()
        {
            var yourDbContext = _context.Slids.Include(s => s.User);
            return View(await yourDbContext.ToListAsync());
        }

        // GET: Slids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Slids == null)
            {
                return NotFound();
            }

            var slid = await _context.Slids
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (slid == null)
            {
                return NotFound();
            }

            return View(slid);
        }

        // GET: Slids/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: Slids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SlidId,UserId,SlidName,SlidUrl")] Slid slid)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slid);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", slid.UserId);
            return View(slid);
        }

        // GET: Slids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Slids == null)
            {
                return NotFound();
            }

            var slid = await _context.Slids.FindAsync(id);
            if (slid == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", slid.UserId);
            return View(slid);
        }

        // POST: Slids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SlidId,UserId,SlidName,SlidUrl")] Slid slid)
        {
            if (id != slid.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slid);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlidExists(slid.UserId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", slid.UserId);
            return View(slid);
        }

        // GET: Slids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Slids == null)
            {
                return NotFound();
            }

            var slid = await _context.Slids
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (slid == null)
            {
                return NotFound();
            }

            return View(slid);
        }

        // POST: Slids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Slids == null)
            {
                return Problem("Entity set 'YourDbContext.Slids'  is null.");
            }
            var slid = await _context.Slids.FindAsync(id);
            if (slid != null)
            {
                _context.Slids.Remove(slid);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlidExists(int id)
        {
          return (_context.Slids?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
