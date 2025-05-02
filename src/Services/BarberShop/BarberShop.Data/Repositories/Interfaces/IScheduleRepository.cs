using BarberShop.Core;
using BarberShop.Domain;

namespace BarberShop.Data
{
    public interface IScheduleRepository : IRepositoryBase<Service>
    {
        Task<List<Service>> GetScheduleByUserId(string userId);
    }
}
