using BarberShop.Core.Base;
using BarberShop.Data.Context;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly BarberShopContext _context;

        public UserRepository(BarberShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> Password(Guid id)
        {
            return await _context.User
                .Where(u => u.Id == id)
                .Select(u => u.Password) 
                .FirstOrDefaultAsync();
        }

        public async Task<bool> EmailUserExists(string email)
        {
            return await _context.User
                .Where(u => u.Email == email).AnyAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.User
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }
    }
}
