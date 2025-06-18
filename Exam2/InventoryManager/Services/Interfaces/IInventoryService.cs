using InventoryManager.Models;
using InventoryManager.Models.Entities;
using InventoryManager.Models.ViewModels;

namespace InventoryManager.Services.Interfaces
{
    public interface IInventoryService
    {
        Task AddAsync(ProductCreateViewModel product);
        Task<List<ProductListViewModel>> GetFilteredProductListAsync(FilterProductModel filter);
    }
}
