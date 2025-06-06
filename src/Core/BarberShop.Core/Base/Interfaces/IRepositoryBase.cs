﻿using System.Linq.Expressions;

namespace BarberShop.Core
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : Entity
    {
        Task<TEntity> GetId(Guid id);
        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Create(TEntity objeto);
        Task<bool> Update(TEntity objeto);
        Task<bool> Delete(Guid id);

        Task<TEntity> GetById(Guid id);
        Task<int> SaveChanges();

    }
}
