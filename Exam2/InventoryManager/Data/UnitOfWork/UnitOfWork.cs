using InventoryManager.Repositories.Interfaces;

namespace InventoryManager.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDbContext _context;

        public IProductRepository ProductRepository { get; }
        public UnitOfWork(IProductRepository productRepository, InventoryDbContext context)
        {
            ProductRepository = productRepository;
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
