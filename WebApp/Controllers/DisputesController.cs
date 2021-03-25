using System;
using System.Threading.Tasks;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using Domain.App;
using Extensions.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.ObjectPool;
using WebApp.Helpers;
using WebApp.ViewModels.Disputes;

namespace WebApp.Controllers
{
    public class DisputesController : Controller
    {
        private readonly IAppUnitOfWork _uow;

        private readonly Singleton _singleton;
        private readonly Transient _transient;
        private readonly Scoped _scoped;
        private readonly IDiScoped _diScoped;
        private readonly IDiSingleton _diSingleton;
        private readonly IDiTransient _diTransient;
        private readonly IServiceProvider _serviceProvider;

        public DisputesController(IAppUnitOfWork uow,Singleton singleton, Transient transient, Scoped scoped, IDiScoped diScoped,
            IDiSingleton diSingleton, IDiTransient diTransient, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _diScoped = diScoped;
            _diSingleton = diSingleton;
            _diTransient = diTransient;
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
            _uow = uow;
        }

        // GET: Disputes
        public async Task<IActionResult> Index()
        {
            var res = await _uow.Disputes.GetAllAsync(User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();

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

            var dispute = await _uow.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new DisputesCreatEditViewModel();
            viewModel.DisputeStatusSelectList = new SelectList(await _uow.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _uow.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisputesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _uow.Disputes.Add(viewModel.Dispute);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.DisputeStatusSelectList = new SelectList(await _uow.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _uow.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // GET: Disputes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _uow.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (dispute == null)
            {
                return NotFound();
            }

            var viewModel = new DisputesCreatEditViewModel();
            viewModel.Dispute = dispute;
            viewModel.DisputeStatusSelectList = new SelectList(await _uow.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue));
            viewModel.ErApplicationSelectList  = new SelectList(await _uow.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment));
            return View(viewModel);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, DisputesCreatEditViewModel viewModel)
        {
            if (id != viewModel.Dispute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _uow.Disputes.Update(viewModel.Dispute);
                await _uow.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.DisputeStatusSelectList = new SelectList(await _uow.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _uow.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // GET: Disputes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _uow.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
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
            await _uow.Disputes.RemoveAsync(id, User.GetUserId()!.Value);
            await _uow.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
