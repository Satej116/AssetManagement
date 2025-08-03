namespace AssetManagement.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(K key, T entity);
        Task<T> DeleteAsync(K key);
        Task<T?> GetByIdAsync(K key);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
