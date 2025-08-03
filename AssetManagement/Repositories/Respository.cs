using AssetManagement.Interfaces;

namespace AssetManagement.Repositories
{
    public abstract class Repository<K, T> : IRepository<K, T> where T : class
    {
        protected static List<T> _list = new List<T>();

        public virtual Task<T> AddAsync(T entity)
        {
            _list.Add(entity);
            return Task.FromResult(entity);
        }

        public virtual async Task<T> UpdateAsync(K key, T entity)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _list.Remove(item);
                _list.Add(entity);
                return entity;
            }
            throw new KeyNotFoundException($"Entity with key {key} not found.");
        }

        public virtual async Task<T> DeleteAsync(K key)
        {
            var item = await GetByIdAsync(key);
            if (item != null)
            {
                _list.Remove(item);
                return item;
            }
            throw new KeyNotFoundException($"Entity with key {key} not found.");
        }

        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<T>>(_list);
        }

        // Abstract so child class must define how to get entity by key
        public abstract Task<T?> GetByIdAsync(K key);
    }
}
