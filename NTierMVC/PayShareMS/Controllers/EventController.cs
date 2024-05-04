using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayShare.DAL.Context;
using PayShare.DAL.Services.Concrete;
using PayShareMS.BLL.Managers.Concrete;
using PayShareMS.DTO;
using PayShareMS.Entities;
using PayShareMS.Models;

namespace PayShareMS.Controllers
{
	public class EventsController : Controller
	{

		private readonly EventManager _eventManager;
        private int _rowNum = 1;

        public EventsController(EventManager eventManager)
		{

			_eventManager = eventManager;
		}

		// GET: Events
		public async Task<IActionResult> Index()
		{
			List<EventDto> eventDtos = _eventManager.GetAll().ToList();
			List<EventEditListViewModel> vm = new List<EventEditListViewModel>();
			foreach (EventDto eventDto in eventDtos)
			{
				EventEditListViewModel vmModel = new EventEditListViewModel();
				vmModel.Id = eventDto.Id;
				vmModel.EventDate = eventDto.EventDate;
				vmModel.Name = eventDto.Name;
				vmModel.RowNum = _rowNum++;
				vm.Add(vmModel);
			}
			return View(vm);
		}

		// GET: Events/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			//if (id == null)
			//{
			//    return NotFound();
			//}

			//var @event = await _context.Events
			//    .FirstOrDefaultAsync(m => m.Id == id);
			//if (@event == null)
			//{
			//    return NotFound();
			//}

			return View();
		}

		// GET: Events/Create
		public IActionResult Create()
		{
			return View(new EventAddViewModel());
		}

		// POST: Events/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Name,EventDate")] EventAddViewModel @event)
		{
			if (!ModelState.IsValid)
			{
				return View(@event);
			}

			EventDto eventDto = new EventDto();
			eventDto.EventDate = @event.EventDate;
			eventDto.Name = @event.Name;
			_eventManager.Add(eventDto);

			if (_eventManager.Add(eventDto) > 0)
			{
				return RedirectToAction(nameof(Index));
			}
			return View(@event);
		}

		// GET: Events/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var @event = _eventManager.GetById(id);
			EventEditListViewModel model = new EventEditListViewModel();
			model.Name = @event.Name;
			model.EventDate = @event.EventDate;

			if (@event == null)
			{
				return NotFound();
			}
			return View(model);
		}

		// POST: Events/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Name,EventDate,Id")] EventEditListViewModel @event)
		{
			if (id != @event.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					EventDto eventDto = new EventDto();
					eventDto.EventDate = @event.EventDate;
					eventDto.Name = @event.Name;
					_eventManager.Update(eventDto);
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!EventExists(@event.Id))
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
			return View(@event);
		}

		// GET: Events/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var @event =  _eventManager.GetById(id);
			EventEditListViewModel model = new EventEditListViewModel();
			model.Id = id;
			model.Name = @event.Name;
			model.EventDate = @event.EventDate;
			if (@event == null)
			{
				return NotFound();
			}

			return View(model);
		}

		// POST: Events/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var @event = _eventManager.GetById(id);
			if (@event != null)
			{
				_eventManager.Delete(@event);
			}
			return RedirectToAction(nameof(Index));
		}

		private bool EventExists(int id)
		{

			return _eventManager.GetAll().Any(e => e.Id == id);
		}
	}
}
