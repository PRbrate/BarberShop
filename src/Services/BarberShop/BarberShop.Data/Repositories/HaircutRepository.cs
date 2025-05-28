using BarberShop.Core;
using BarberShop.Domain;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data
{
    public class HaircutRepository : RepositoryBase<Haircut>, IHaircutRepository
    {
        private readonly BarberShopContext _context;
        public HaircutRepository(BarberShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Haircut>> GetListHaicurt(string userId, bool status)
        {
            var totalcount = _context.Haircut.Count();

            var items = await _context.Haircut.Where(c=> c.UserId == userId && c.Status == status).OrderBy(p => p.Price).ToListAsync();

            return items;
        }


        public int GetCount(string userId)
        {
            return _context.Haircut.Where(c=> c.UserId == userId).Count();
        }
    }
}
