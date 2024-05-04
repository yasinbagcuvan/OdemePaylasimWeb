using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayShare.DAL.Context;
using PayShareMS.BLL.Managers.Concrete;
using PayShareMS.DTO;
using PayShareMS.Entities;
using PayShareMS.Models;

namespace PayShareMS.Controllers
{
    public class GeneralLedgerController : Controller
    {
		private readonly GeneralLedgerManager _GeneralLedgerManager;
		private readonly PersonManager _personManager;
		private readonly EventManager _eventManager;
		private readonly ProductManager _productManager;
        private int _rowNum = 1;
		public GeneralLedgerController(GeneralLedgerManager GeneralLedgerManager, PersonManager personManager, EventManager eventManager, ProductManager productManager)
		{

			_GeneralLedgerManager = GeneralLedgerManager;
			_personManager = personManager;
			_eventManager = eventManager;
			_productManager = productManager;
		}

		// GET: GeneralLedger
		public async Task<IActionResult> Index()
        {
			List<GeneralLedgerDto> GeneralLedgerDtos = _GeneralLedgerManager.GetAll().ToList();
			List<GeneralLedgerEditListViewModel> vm = new List<GeneralLedgerEditListViewModel>();
			foreach (GeneralLedgerDto Dto in GeneralLedgerDtos)
			{
				GeneralLedgerEditListViewModel vmModel = new GeneralLedgerEditListViewModel();
				vmModel.Id = Dto.Id;
				vmModel.IsPaid = Dto.IsPaid;
				vmModel.Amount = Dto.Amount;
                vmModel.RowNum = _rowNum;
				vm.Add(vmModel);
			}
			return View(vm);
		}

        // GET: GeneralLedger/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var generalLedger = await _context.GeneralLedgers
            //    .Include(g => g.DebtorPerson)
            //    .Include(g => g.Event)
            //    .Include(g => g.PayeePerson)
            //    .Include(g => g.Product)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (generalLedger == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: GeneralLedger/Create
        public IActionResult Create()
        {
            ViewData["DebtorPersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name");
            ViewData["EventId"] = new SelectList(_eventManager.GetAll(), "Id", "Name");
            ViewData["PayeePersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name");
            ViewData["ProductId"] = new SelectList(_productManager.GetAll(), "Id", "Name");
            return View(new GeneralLedgerAddViewModel());
        }

        // POST: GeneralLedger/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PayeePersonId,DebtorPersonId,EventId,ProductId,Amount,IsPaid")] GeneralLedgerAddViewModel generalLedger)
        {
            if (ModelState.IsValid)
            {
                GeneralLedgerDto dto = new GeneralLedgerDto();
                dto.Amount = generalLedger.Amount;
                dto.IsPaid = generalLedger.IsPaid;
                dto.DebtorPersonId = generalLedger.DebtorPersonId;
                dto.PayeePersonId = generalLedger.PayeePersonId;
                dto.EventId = generalLedger.EventId;
                dto.ProductId = generalLedger.ProductId;
                
                _GeneralLedgerManager.Add(dto);

                return RedirectToAction(nameof(Index));
            }
            ViewData["DebtorPersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.DebtorPersonId);
            ViewData["EventId"] = new SelectList(_eventManager.GetAll(), "Id", "Name", generalLedger.EventId);
            ViewData["PayeePersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.PayeePersonId);
            ViewData["ProductId"] = new SelectList(_productManager.GetAll(), "Id", "Name", generalLedger.ProductId);
            return View(generalLedger);
        }

        // GET: GeneralLedger/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalLedger =  _GeneralLedgerManager.GetById(id);
            if (generalLedger == null)
            {
                return NotFound();
            }
			ViewData["DebtorPersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.DebtorPersonId);
			ViewData["EventId"] = new SelectList(_eventManager.GetAll(), "Id", "Name", generalLedger.EventId);
			ViewData["PayeePersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.PayeePersonId);
			ViewData["ProductId"] = new SelectList(_productManager.GetAll(), "Id", "Name", generalLedger.ProductId);
			return View(generalLedger);
        }

        // POST: GeneralLedger/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PayeePersonId,DebtorPersonId,EventId,ProductId,Amount,IsPaid,Id")] GeneralLedgerEditListViewModel generalLedger)
        {
            if (id != generalLedger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					GeneralLedgerDto dto = new GeneralLedgerDto();
					dto.Amount = generalLedger.Amount;
					dto.IsPaid = generalLedger.IsPaid;
					_GeneralLedgerManager.Update(dto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GeneralLedgerExists(generalLedger.Id))
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
			ViewData["DebtorPersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.DebtorPersonId);
			ViewData["EventId"] = new SelectList(_eventManager.GetAll(), "Id", "Name", generalLedger.EventId);
			ViewData["PayeePersonId"] = new SelectList(_personManager.GetAll(), "Id", "Name", generalLedger.PayeePersonId);
			ViewData["ProductId"] = new SelectList(_productManager.GetAll(), "Id", "Name", generalLedger.ProductId);
			return View(generalLedger);
        }

        // GET: GeneralLedger/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var generalLedger =  _GeneralLedgerManager.GetById(id);
            GeneralLedgerEditListViewModel model = new GeneralLedgerEditListViewModel();
            model.IsPaid = generalLedger.IsPaid;
            model.Amount = generalLedger.Amount;
            model.PayeePersonId = generalLedger.PayeePersonId;
            model.DebtorPersonId = generalLedger.DebtorPersonId;
            model.ProductId = generalLedger.ProductId;
                
            if (generalLedger == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: GeneralLedger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var generalLedger = _GeneralLedgerManager.GetById(id);
			if (generalLedger != null)
            {
                _GeneralLedgerManager.Delete(generalLedger);
            }


            return RedirectToAction(nameof(Index));
        }

        private bool GeneralLedgerExists(int id)
        {
            return _GeneralLedgerManager.GetAll().Any(e => e.Id == id);
        }
    }
}
