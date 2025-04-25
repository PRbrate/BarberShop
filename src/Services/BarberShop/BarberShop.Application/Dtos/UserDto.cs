using BarberShop.Domain.Entities;

namespace BarberShop.Application
{
    public record UserDTO(string id, string Name, string Email, string Address, List<SubscriptionDTO> Subscriptions);
}
