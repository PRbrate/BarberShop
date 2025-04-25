using BarberShop.Core.Base.Interfaces;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Data.Repositories.Interfaces
{
    public interface IUserRepository 
    {
        Task<List<User>> GetList();
        Task<User> GetFindByEmailAsync(string email);
        void Dispose();
    }
}
