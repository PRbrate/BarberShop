using BarberShop.Core;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class ScheduleRepository(BarberShopContext context) : RepositoryBase<Service>(context), IScheduleRepository
    {
        private readonly BarberShopContext _context = context;

        public async Task<List<Service>> GetScheduleByUserId(string userId)
        {
            var schedules = await _context.Service
                .Include(x => x.User)
                .Include(x => x.Haircut)
                .Where(x => x.UserId == userId).ToListAsync();

            return schedules;
        }
    }
}
