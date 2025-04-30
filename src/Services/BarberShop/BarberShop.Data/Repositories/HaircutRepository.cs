using BarberShop.Core;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain;

namespace BarberShop.Data.Repositories
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
