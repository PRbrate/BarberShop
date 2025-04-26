using BarberShop.Core.Base;
using BarberShop.Data.Context;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BarberShopContext _context;

        public UserRepository(BarberShopContext context)
        {
            _context = context;
        }

        public void Dispose() => _context.Dispose();

        public async Task<List<User>> GetList()
        {
            var user = await _context.Users.ToListAsync();

            return user;
        }
        public async Task<User> GetFindByEmailAsync(string email)
        {
            var user = await _context.Users
                        .Include(u => u.Subscriptions)
                        .FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }
        public async Task<User> GetUserFromId(string id)
        {
            var user = await _context.Users
                        .Include(u => u.Subscriptions)
                        .FirstOrDefaultAsync(u => u.Id == id);

            return user;
        }

    }
}
