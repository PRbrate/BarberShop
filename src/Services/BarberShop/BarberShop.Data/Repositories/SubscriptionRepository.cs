using BarberShop.Core;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data.Repositories
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
