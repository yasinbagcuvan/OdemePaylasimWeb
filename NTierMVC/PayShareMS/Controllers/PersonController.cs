using System;
using System.Collections.Generic;
using System.Linq;
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
    public class PersonController : Controller
    {
        private readonly PersonManager _personManager;
        private int _rowNum = 1;

        public PersonController(PersonManager personManager)
        {
			_personManager = personManager;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            List<PersonDto> personDtos = _personManager.GetAll().ToList();
            List<PersonEditListViewModel> vm = new List<PersonEditListViewModel>();
            foreach (PersonDto personDto in personDtos)
            {
                PersonEditListViewModel viewModel = new PersonEditListViewModel();
                viewModel.Id = personDto.Id;
                viewModel.Name = personDto.Name;
                viewModel.Surname = personDto.Surname;
                viewModel.RowNum = _rowNum++;
                vm.Add(viewModel);
            }

			return View(vm);
        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var person = await _context.Persons
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (person == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View(new PersonAddViewModel());
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Surname")] PersonAddViewModel person)
        {
            if (ModelState.IsValid)
            {
                PersonDto personDto = new PersonDto();
				personDto.Name = person.Name;
                personDto.Surname = person.Surname;
				_personManager.Add(personDto);
                
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personManager.GetById(id);
            PersonEditListViewModel model = new PersonEditListViewModel();
            model.Id = person.Id;
            model.Name = person.Name;
            model.Surname = person.Surname;
            if (person == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Surname,Id")] PersonEditListViewModel person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					PersonDto peDto = new PersonDto();
					peDto.Id = person.Id;
					peDto.Name = person.Name;
					peDto.Surname = person.Surname;
					_personManager.Update(peDto);
				}
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<IActionResult>Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = _personManager.GetById(id);
            PersonEditListViewModel viewModel = new PersonEditListViewModel();
            viewModel.Id = id;
            viewModel.Name = person.Name;
            viewModel.Surname = person.Surname;
            if (person == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = _personManager.GetById(id);
			if (person != null)
            {
                _personManager.Delete(person);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _personManager.GetAll().Any(e => e.Id == id);
        }
    }
}
