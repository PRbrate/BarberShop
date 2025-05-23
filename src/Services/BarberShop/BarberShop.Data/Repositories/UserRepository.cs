﻿using BarberShop.Core.Base;
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

    }
}
