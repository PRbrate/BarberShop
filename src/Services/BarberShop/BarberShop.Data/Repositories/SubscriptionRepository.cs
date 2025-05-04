using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public class SubscriptionRepository : RepositoryBase<Subscription>, ISubscriptionRepository
    {
        private readonly BarberShopContext _context;
        public SubscriptionRepository(BarberShopContext context) : base(context)
        {
            _context = context;
        }
    }
}
