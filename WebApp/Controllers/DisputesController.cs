using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Applications.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain.App;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.ObjectPool;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    public class DisputesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IDisputeRepository _repository;

        private readonly Singleton _singleton;
        private readonly Transient _transient;
        private readonly Scoped _scoped;
        private readonly IDiScoped _diScoped;
        private readonly IDiSingleton _diSingleton;
        private readonly IDiTransient _diTransient;
        private readonly IServiceProvider _serviceProvider;

        public DisputesController(AppDbContext context, IDisputeRepository repository
            , Singleton singleton, Transient transient, Scoped scoped, IDiScoped diScoped,
            IDiSingleton diSingleton, IDiTransient diTransient, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _diScoped = diScoped;
            _diSingleton = diSingleton;
            _diTransient = diTransient;
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
            _context = context;
            _repository = repository;
        }

        // GET: Disputes
        public async Task<IActionResult> Index()
        {
            var res = await _repository.GetAllAsync();

            return View(res);
        }

        public string TestId()
        {
            var res = $"singleton id: {_singleton.Id}, transient id: {_transient.Id}, scoped id: {_scoped.Id}";
            var singleton = _serviceProvider.GetService(typeof(Singleton)) as Singleton;
            var transient = _serviceProvider.GetService(typeof(Transient)) as Transient;
            var scoped = _serviceProvider.GetService(typeof(Scoped)) as Scoped;

            var res2 = $"singleton id: {singleton?.Id}, transient id: {transient?.Id}, scoped id: {scoped?.Id}";

            return res + "\n" + res2;
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
        public async Task<IActionResult> Create(
            [Bind("Id,Title,Comment,DisputeStatusId,ErApplicationId,CreatedOn,UpdatedOn")]
            Dispute dispute)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(dispute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue",
                dispute.DisputeStatusId);
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

            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue",
                dispute.DisputeStatusId);
            ViewData["ErApplicationId"] = new SelectList(_context.ErApplications, "Id", "Id", dispute.ErApplicationId);
            return View(dispute);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id,
            [Bind("Id,Title,Comment,DisputeStatusId,ErApplicationId,CreatedOn,UpdatedOn")]
            Dispute dispute)
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

            ViewData["DisputeStatusId"] = new SelectList(_context.DisputeStatuses, "Id", "DisputeStatusValue",
                dispute.DisputeStatusId);
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
