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
    public class UFilesController : Controller
    {
        private readonly SlideAppDbContext _context;

        public UFilesController(SlideAppDbContext context)
        {
            _context = context;
        }

        // GET: UFiles
        public async Task<IActionResult> Index()
        {
            var yourDbContext = _context.UFiles.Include(u => u.User);
            return View(await yourDbContext.ToListAsync());
        }

        // GET: UFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UFiles == null)
            {
                return NotFound();
            }

            var uFile = await _context.UFiles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (uFile == null)
            {
                return NotFound();
            }

            return View(uFile);
        }

        // GET: UFiles/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: UFiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name,ImageUrl,VideoUrl")] UFile uFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", uFile.UserId);
            return View(uFile);
        }

        // GET: UFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UFiles == null)
            {
                return NotFound();
            }

            var uFile = await _context.UFiles.FindAsync(id);
            if (uFile == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", uFile.UserId);
            return View(uFile);
        }

        // POST: UFiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name,ImageUrl,VideoUrl")] UFile uFile)
        {
            if (id != uFile.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UFileExists(uFile.UserId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", uFile.UserId);
            return View(uFile);
        }

        // GET: UFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UFiles == null)
            {
                return NotFound();
            }

            var uFile = await _context.UFiles
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (uFile == null)
            {
                return NotFound();
            }

            return View(uFile);
        }

        // POST: UFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UFiles == null)
            {
                return Problem("Entity set 'YourDbContext.UFiles'  is null.");
            }
            var uFile = await _context.UFiles.FindAsync(id);
            if (uFile != null)
            {
                _context.UFiles.Remove(uFile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UFileExists(int id)
        {
          return (_context.UFiles?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
