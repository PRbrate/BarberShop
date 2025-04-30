using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public class HaircutRepository : RepositoryBase<Haircut>, IHaircutRepository
    {
        private readonly BarberShopContext _context;
        public HaircutRepository(BarberShopContext context) : base(context)
        {
            _context = context;
        }

    }
}
