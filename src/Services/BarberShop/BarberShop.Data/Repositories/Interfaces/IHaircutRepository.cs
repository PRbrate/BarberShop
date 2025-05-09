using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public interface IHaircutRepository : IRepositoryBase<Haircut>
    {
        Task<PaginationResult<Haircut>> GetListHaicurt(int pageIndex, int pageSize);
        int GetCount(string userId);
        Task<bool> UpdateStatus(Haircut haircut);
    }
}
