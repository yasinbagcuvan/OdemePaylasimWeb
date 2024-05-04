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
    public class ProductController : Controller
    {
        private readonly ProductManager _productManager;
        private int _rowNum = 1;

        public ProductController(ProductManager productManager)
        {
			_productManager = productManager;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
			List<ProductDto> ProductDtos = _productManager.GetAll().ToList();
			List<ProductEditListViewModel> vm = new List<ProductEditListViewModel>();
			foreach (ProductDto ProductDto in ProductDtos)
			{
				ProductEditListViewModel vmModel = new ProductEditListViewModel();
				vmModel.Id = ProductDto.Id;
				vmModel.Price = ProductDto.Price;
				vmModel.Name = ProductDto.Name;
                vmModel.RowNum = _rowNum++;

                vm.Add(vmModel);
			}
			return View(vm);
		}

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var product = await _context.Products
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View(new ProductAddViewModel());
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Price")] ProductAddViewModel product)
        {
            if (ModelState.IsValid)
            {
                ProductDto ProductDto = new ProductDto();
                ProductDto.Price = product.Price;
                ProductDto.Name = product.Name;

                _productManager.Add(ProductDto);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetById(id);
            ProductEditListViewModel model = new ProductEditListViewModel();
            model.Price = product.Price;
            model.Name = product.Name;
            model.Id = product.Id;
            if (product == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Price,Id")] ProductEditListViewModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
					ProductDto tDto = new ProductDto();
					tDto.Id = product.Id;
					tDto.Price = product.Price;
					tDto.Name = product.Name;
                    _productManager.Update(tDto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _productManager.GetById(id);
            ProductEditListViewModel model = new ProductEditListViewModel();
            model.Id = product.Id;
            model.Name = product.Name;
            model.Price = product.Price;
               
            if (product == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = _productManager.GetById(id);
			if (product != null)
            {
                _productManager.Delete(product);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _productManager.GetAll().Any(e => e.Id == id);
        }
    }
}
