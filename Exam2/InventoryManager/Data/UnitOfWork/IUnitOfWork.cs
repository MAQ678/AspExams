using InventoryManager.Repositories.Interfaces;

namespace InventoryManager.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        Task<int> SaveAsync();
    }
}
