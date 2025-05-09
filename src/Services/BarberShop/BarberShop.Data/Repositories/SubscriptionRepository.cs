using BarberShop.Core;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        private readonly BarberShopContext _context;
        public SubscriptionRepository(BarberShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Subscription>> GetSubscriptionsFromUser(string userId)
        {
            var subscriptions = await _context.Subscription
                        .Where(Subscription => Subscription.UserId == userId).ToListAsync();

            return subscriptions;
        }
        public bool HasSubscriptionsFromUser(string userId)
        {
            var subscriptions =  _context.Subscription
                        .Any(Subscription => Subscription.UserId == userId && Subscription.Status != true);

            return subscriptions;
        }
    }
}
