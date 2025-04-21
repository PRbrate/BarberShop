using BarberShop.Application.Dtos;
using BarberShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserDto users);
        Task<Response<string>> Authenticate(string email, string password);

    }
}
