using System.Linq.Expressions;

namespace BarberShop.Core
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAllAsync();
        Task<bool> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        public bool Detached(T entity);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);

    }
}
