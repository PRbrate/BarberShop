using BarberShop.Domain;

namespace BarberShop.Application
{
    public interface IJwtService
    {
        Task<UserToken> GenerateJwt(User user);
    }
}
