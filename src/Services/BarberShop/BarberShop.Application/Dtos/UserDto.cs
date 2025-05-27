using BarberShop.Domain;

namespace BarberShop.Application
{
    public record UserDTO(string id, string Name, string Email, string Address, SubscriptionDTO Subscriptions);
}
