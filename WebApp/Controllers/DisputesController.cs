using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain.App;

namespace WebApp.Controllers
{
    public class DisputesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly DisputeRepository _repository;

        public DisputesController(AppDbContext context)
        {
            _context = context;
            _repository = new DisputeRepository(_context);
        }

        // GET: Disputes
        public async Task<IActionResult> Index()
        {
            var res = await _repository.GetAllAsync();
         
            return View(res);
        }

        // GET: Disputes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        public IActionResult Create()
        {
            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue");
            ViewData["ErApplicationId"] = new SelectList(_context.ErApplications, "Id", "Id");
            return View();
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Comment,DisputeStatusId,ErApplicationId,CreatedOn,UpdatedOn")] Dispute dispute)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(dispute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue", dispute.DisputeStatusId);
            ViewData["ErApplicationId"] = new SelectList(_context.ErApplications, "Id", "Id", dispute.ErApplicationId);
            return View(dispute);
        }

        // GET: Disputes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes.FindAsync(id);
            if (dispute == null)
            {
                return NotFound();
            }
            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue", dispute.DisputeStatusId);
            ViewData["ErApplicationId"] = new SelectList(_context.ErApplications, "Id", "Id", dispute.ErApplicationId);
            return View(dispute);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Comment,DisputeStatusId,ErApplicationId,CreatedOn,UpdatedOn")] Dispute dispute)
        {
            if (id != dispute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dispute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisputeExists(dispute.Id))
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
            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue", dispute.DisputeStatusId);
            ViewData["ErApplicationId"] = new SelectList(_context.ErApplications, "Id", "Id", dispute.ErApplicationId);
            return View(dispute);
        }

        // GET: Disputes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _context.Disputes
                .Include(d => d.DisputeStatus)
                .Include(d => d.ErApplication)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: Disputes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var dispute = await _context.Disputes.FindAsync(id);
            _context.Disputes.Remove(dispute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisputeExists(Guid id)
        {
            return _context.Disputes.Any(e => e.Id == id);
        }
    }
}
