using System.Linq.Expressions;

namespace BarberShop.Core
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Create(TEntity objeto);
        Task<bool> Update(TEntity objeto);
        Task Delete(Guid id);
        Task<int> SaveChanges();

    }
}
