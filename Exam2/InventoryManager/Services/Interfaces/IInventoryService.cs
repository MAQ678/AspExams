using InventoryManager.Models;
using InventoryManager.Models.ViewModels;

namespace InventoryManager.Services.Interfaces
{
    public interface IInventoryService
    {
        Task AddAsync(ProductCreateViewModel product);
        Task<ProductEditViewModel?> GetProductEditViewModelByIdAsync(int id);
        Task<ProductInfoViewModel?> GetProductInfoViewModelByIdAsync(int id);
        Task<List<ProductInfoViewModel>> GetFilteredProductListAsync(FilterProductModel filter);
        Task<bool> UpdateAsync(ProductEditViewModel product);
        Task DeleteByIdAsync(int id);
    }
}
