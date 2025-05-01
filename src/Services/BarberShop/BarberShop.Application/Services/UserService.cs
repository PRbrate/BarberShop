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

        public async Task<SubscriptionDTO> CheckSubscription(string id)
        {
            var subscriptions = _userRepository.GetUserFromId(id).Result.Subscriptions.FirstOrDefault();

            if (subscriptions == null) return null;

            var map = AutoMapperSubscription.Map(subscriptions);

            return map;
        }

        public async Task<User> GetFindByEmailAsync(string email)
        {
            return await _userRepository.GetFindByEmailAsync(email);
        }
        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userRepository.GetUserFromId(id);

            return user.Map();
        }
        public async Task<bool> Update(UserDTQ userDTQ)
        {
            var user = await _userRepository.GetUserFromId(userDTQ.Id);
            if (user == null) return false;

            user.Name = userDTQ.Name;
            user.Address = userDTQ.Address;

            return await _userRepository.Update(user);
        }
    }
}