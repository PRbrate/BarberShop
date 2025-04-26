using BarberShop.Application.Services.Interfaces;
using BarberShop.Core.Entities;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;

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

        public async Task<User> GetFindByEmailAsync(string email)
        {
            return await _userRepository.GetFindByEmailAsync(email);
        }
        public async Task<UserDTO> GetUserFromId(string id)
        {
            var user =  await _userRepository.GetUserFromId(id);

            return user.Map();
        }
    }
}