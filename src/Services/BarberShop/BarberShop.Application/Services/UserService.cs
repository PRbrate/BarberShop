using BarberShop.Core;
using BarberShop.Data;
using BarberShop.Domain;

namespace BarberShop.Application
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
            var user = await _userRepository.GetUserFromId(id);

            return user.Map();
        }
        public async Task<bool> Update(UserDTQ userDTQ)
        {
            var user = await _userRepository.GetUserFromId(userDTQ.Id);
            if (user == null) return false;

            user.Name = userDTQ.Name;
            user.Email = userDTQ.Email;

            return await _userRepository.Update(user);
        }
    }
}