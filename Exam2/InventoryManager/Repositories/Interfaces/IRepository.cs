namespace InventoryManager.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        void Add(T product);
        void Update(T product);
        void Delete(T product);
        IQueryable<T> Query();
    }
}
