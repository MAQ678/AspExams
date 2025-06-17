using InventoryManager.Repositories.Interfaces;

namespace InventoryManager.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepositroy ProductRepository { get; }
        Task<int> SaveAsync();
    }
}
