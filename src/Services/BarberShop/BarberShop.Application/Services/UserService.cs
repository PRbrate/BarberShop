using BarberShop.Application.Dtos;
using BarberShop.Application.MappingsConfig;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Application.Services.OtherServices;
using BarberShop.Core.Entities;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;
using BarberShop.Domain.Entities.Validations.Services;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public Task<Response<string>> Authenticate(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateUser(UserDto users)
        {
            throw new NotImplementedException();
        }
    }
}