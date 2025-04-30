using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public class ScheduleRepository(BarberShopContext context) : RepositoryBase<Service>(context), IScheduleRepository
    {
        private readonly BarberShopContext _context = context;
    }
}
