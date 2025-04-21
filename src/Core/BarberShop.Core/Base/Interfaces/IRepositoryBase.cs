using BarberShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Core.Base.Interfaces
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> GetAsync(int id);
        IQueryable<T> GetAllAsync();
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        public bool Detached(T entity);

    }
}
