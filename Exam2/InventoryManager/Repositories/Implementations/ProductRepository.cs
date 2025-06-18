using InventoryManager.Data;
using InventoryManager.Models.Entities;
using InventoryManager.Repositories.Interfaces;

namespace InventoryManager.Repositories.Implementations
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(InventoryDbContext context) : base(context)
        {
        }
    }
}
