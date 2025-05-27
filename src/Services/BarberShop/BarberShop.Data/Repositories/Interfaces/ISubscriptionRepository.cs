using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public interface ISubscriptionRepository : IRepositoryBase<Subscription>
    {
        Task<List<Subscription>> GetSubscriptionsFromUser(string userId);
        bool HasSubscriptionsFromUser(string userId);
    }
}
