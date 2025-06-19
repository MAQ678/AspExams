using InventoryManager.Models;
using InventoryManager.Models.Entities;
using InventoryManager.Models.ViewModels;

namespace InventoryManager.Services.Interfaces
{
    public interface IInventoryService
    {
        Task AddAsync(ProductCreateViewModel product);
        Task<ProductEditViewModel?> GetByIdAsync(int id);
        Task<List<ProductListViewModel>> GetFilteredProductListAsync(FilterProductModel filter);
        Task<bool> UpdateAsync(ProductEditViewModel product);
    }
}
