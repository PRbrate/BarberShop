using BarberShop.Core;

namespace BarberShop.Application
{
    public interface IHaircutService
    {
        Task<bool> CreateHaircut(HaircutDTQ haircutDto);
        Task<bool> DeleteHaircut(Guid haircutId);
        Task<PaginationResult<HaircutDto>> GetAllHaircutAsync(string userId, int pageIndex, int pageSize);
        Task<HaircutDto> GetHaircut(Guid id, string userId);
        Task<bool> UpdateHaircut(HaircutDTQ haircutDtq);

    }
}
