using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using Domain;

namespace WebApp.Controllers
{
    public class ErUserTypesController : Controller
    {
        private readonly AppDbContext _context;

        public ErUserTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ErUserTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ErUserTypes.ToListAsync());
        }

        // GET: ErUserTypes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserType = await _context.ErUserTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserType == null)
            {
                return NotFound();
            }

            return View(erUserType);
        }

        // GET: ErUserTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErUserTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserType")] ErUserType erUserType)
        {
            if (ModelState.IsValid)
            {
                erUserType.Id = Guid.NewGuid();
                _context.Add(erUserType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(erUserType);
        }

        // GET: ErUserTypes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserType = await _context.ErUserTypes.FindAsync(id);
            if (erUserType == null)
            {
                return NotFound();
            }
            return View(erUserType);
        }

        // POST: ErUserTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,UserType")] ErUserType erUserType)
        {
            if (id != erUserType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(erUserType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ErUserTypeExists(erUserType.Id))
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
            return View(erUserType);
        }

        // GET: ErUserTypes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var erUserType = await _context.ErUserTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (erUserType == null)
            {
                return NotFound();
            }

            return View(erUserType);
        }

        // POST: ErUserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var erUserType = await _context.ErUserTypes.FindAsync(id);
            _context.ErUserTypes.Remove(erUserType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ErUserTypeExists(Guid id)
        {
            return _context.ErUserTypes.Any(e => e.Id == id);
        }
    }
}
