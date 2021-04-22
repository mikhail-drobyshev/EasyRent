using System;
using System.Threading.Tasks;
using Applications.BLL.App;
using Applications.BLL.Base;
using Applications.DAL.App;
using Applications.DAL.App.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.App.EF;
using DAL.App.EF.Repositories;
using DAL.App.DTO;
using Extensions.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.ObjectPool;
using WebApp.Helpers;
using WebApp.ViewModels.Disputes;

namespace WebApp.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class DisputesController : Controller
    {
        private readonly IAppBLL _bll;

        private readonly Singleton _singleton;
        private readonly Transient _transient;
        private readonly Scoped _scoped;
        private readonly IDiScoped _diScoped;
        private readonly IDiSingleton _diSingleton;
        private readonly IDiTransient _diTransient;
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="singleton"></param>
        /// <param name="transient"></param>
        /// <param name="scoped"></param>
        /// <param name="diScoped"></param>
        /// <param name="diSingleton"></param>
        /// <param name="diTransient"></param>
        /// <param name="serviceProvider"></param>
        /// <param name="bll"></param>
        public DisputesController(Singleton singleton, Transient transient, Scoped scoped, IDiScoped diScoped,
            IDiSingleton diSingleton, IDiTransient diTransient, IServiceProvider serviceProvider, IAppBLL bll)
        {
            _serviceProvider = serviceProvider;
            _bll = bll;
            _diScoped = diScoped;
            _diSingleton = diSingleton;
            _diTransient = diTransient;
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
        }

        // GET: Disputes
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var res = await _bll.Disputes.GetAllAsync(User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();

            return View(res);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _bll.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // GET: Disputes/Create
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            var viewModel = new DisputesCreatEditViewModel();
            viewModel.DisputeStatusSelectList = new SelectList(await _bll.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _bll.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // POST: Disputes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DisputesCreatEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _bll.Disputes.Add(viewModel.Dispute);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.DisputeStatusSelectList = new SelectList(await _bll.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _bll.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // GET: Disputes/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _bll.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (dispute == null)
            {
                return NotFound();
            }

            var viewModel = new DisputesCreatEditViewModel();
            viewModel.Dispute = dispute;
            viewModel.DisputeStatusSelectList = new SelectList(await _bll.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue));
            viewModel.ErApplicationSelectList  = new SelectList(await _bll.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment));
            return View(viewModel);
        }

        // POST: Disputes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
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
                _bll.Disputes.Update(viewModel.Dispute);
                await _bll.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            viewModel.DisputeStatusSelectList = new SelectList(await _bll.DisputeStatuses.GetAllAsync(), nameof(DisputeStatus.Id), nameof(DisputeStatus.DisputeStatusValue), viewModel.Dispute.DisputeStatusId);
            viewModel.ErApplicationSelectList  = new SelectList(await _bll.ErApplications.GetAllAsync(), nameof(ErApplication.Id), nameof(ErApplication.Comment), viewModel.Dispute.ErApplicationId);
            return View(viewModel);
        }

        // GET: Disputes/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dispute = await _bll.Disputes.FirstOrDefaultAsync(id.Value, User.GetUserId()!.Value);
            if (dispute == null)
            {
                return NotFound();
            }

            return View(dispute);
        }

        // POST: Disputes/Delete/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bll.Disputes.RemoveAsync(id, User.GetUserId()!.Value);
            await _bll.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        
    }
}
