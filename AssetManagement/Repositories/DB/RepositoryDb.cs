using AssetManagement.Contexts;
using AssetManagement.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Repositories.DB
{
    public abstract class RepositoryDb<K, T> : IRepository<K, T> where T : class
    {
        protected readonly AssetManagementDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public RepositoryDb(AssetManagementDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(K key, T entity)
        {
            var existing = await GetByIdAsync(key);
            if (existing == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with key {key} not found.");

            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> DeleteAsync(K key)
        {
            var entity = await GetByIdAsync(key);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(T).Name} with key {key} not found.");

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        // Virtual so we can override to add navigation properties
        public virtual async Task<T?> GetByIdAsync(K key)
        {
            return await _dbSet.FindAsync(key);
        }

        // Virtual so we can override for eager loading
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
