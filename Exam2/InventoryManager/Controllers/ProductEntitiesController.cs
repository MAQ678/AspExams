using InventoryManager.Models;
using InventoryManager.Models.ViewModels;
using InventoryManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManager.Controllers
{
    public class ProductEntitiesController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public ProductEntitiesController(IInventoryService inventoryService)
        {
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
            var productInfoViewModel = await _inventoryService.GetProductInfoViewModelByIdAsync(id.Value);
            if (productInfoViewModel == null)
            {
                return NotFound();
            }

            return View(productInfoViewModel);
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

            var productEditViewModel = await _inventoryService.GetProductEditViewModelByIdAsync(id.Value);
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

            var productInfoViewModel = await _inventoryService.GetProductInfoViewModelByIdAsync(id.Value);
            if (productInfoViewModel == null)
            {
                return NotFound();
            }

            return View(productInfoViewModel);
        }

        // POST: ProductEntities/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedAsync(int id)
        {
            await _inventoryService.DeleteByIdAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
