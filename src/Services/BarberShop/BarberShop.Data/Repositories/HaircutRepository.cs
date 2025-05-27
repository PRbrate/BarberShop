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

            var items = await _context.Haircut.Where(c=> c.UserId == userId && status).OrderBy(p => p.Price).ToListAsync();

            return items;
        }
        public async Task<bool> UpdateStatus(Haircut haircut)
        {
            _context.Haircut.Attach(haircut);

            _context.Entry(haircut).Property(h => h.Status).IsModified = true;
            _context.Entry(haircut).Property(h => h.UpdatedAt).IsModified = true;
            return await SaveChanges() > 0;
        }

        public int GetCount(string userId)
        {
            return _context.Haircut.Where(c=> c.UserId == userId).Count();
        }
    }
}
