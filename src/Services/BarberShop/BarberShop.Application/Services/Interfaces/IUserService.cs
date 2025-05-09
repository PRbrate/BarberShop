using BarberShop.Domain;

namespace BarberShop.Application
{
    public interface IUserService
    {
        Task<UserDTO> GetUserById(string id);
        Task<User> GetFindByEmailAsync(string email);
        Task<bool> Update(UserDTQ userDTQ);

    }
}
