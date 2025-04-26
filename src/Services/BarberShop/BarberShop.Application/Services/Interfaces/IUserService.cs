using BarberShop.Domain.Entities;

namespace BarberShop.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserFromId(string id);
        Task<User> GetFindByEmailAsync(string email);

    }
}
