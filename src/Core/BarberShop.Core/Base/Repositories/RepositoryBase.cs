using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Core
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<bool> Create(T entity)
        {

            var TCreated = await _dbSet.AddAsync(entity);
            return await SaveChanges() > 0;

        }

        public async Task<T> Delete(T entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified; 
            await _context.SaveChangesAsync();
            return entity;

        }

        public IQueryable<T> GetAllAsync()
        {
            return _dbSet.AsQueryable<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool Detached(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Detached;
            return true;
        }

        public async Task<int> SaveChanges() => await _context.SaveChangesAsync();

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate) => await _dbSet.AsNoTrackingWithIdentityResolution().Where(predicate).ToListAsync();

        public void Dispose() =>
            _context?.Dispose();

    }
}