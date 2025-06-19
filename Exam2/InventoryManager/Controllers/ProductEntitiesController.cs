using InventoryManager.Data;
using InventoryManager.Models;
using InventoryManager.Models.Entities;
using InventoryManager.Models.ViewModels;
using InventoryManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.Controllers
{
    public class ProductEntitiesController : Controller
    {
        private readonly InventoryDbContext _context;
        private readonly IInventoryService _inventoryService;

        public ProductEntitiesController(InventoryDbContext context, IInventoryService inventoryService)
        {
            _context = context;
            _inventoryService = inventoryService;
        }

        // GET: ProductEntities
        public async Task<IActionResult> Index([FromQuery] FilterProductModel filter)
        {
            var productListViewModels = await _inventoryService.GetFilteredProductListAsync(filter);
            return View(productListViewModels);
        }

        // GET: ProductEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Products == null)
            {
                return NotFound();
            }

            return View(Products);
        }

        // GET: ProductEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _inventoryService.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: ProductEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productEditViewModel = await _inventoryService.GetByIdAsync(id.Value);
            if (productEditViewModel == null)
            {
                return NotFound();
            }
            return View(productEditViewModel);
        }

        // POST: ProductEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            bool isSuccess = await _inventoryService.UpdateAsync(product);
            if (!isSuccess)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: ProductEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Products = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Products == null)
            {
                return NotFound();
            }

            return View(Products);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Products = await _context.Products.FindAsync(id);
            if (Products != null)
            {
                _context.Products.Remove(Products);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
