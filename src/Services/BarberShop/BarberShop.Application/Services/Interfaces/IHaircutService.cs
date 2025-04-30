using BarberShop.Core;

namespace BarberShop.Application
{
    public interface IHaircutService
    {
        Task<bool> CreateHaircut(HaircutDTQ haircutDto);
        Task<bool> DeleteHaircut(Guid haircutId);
        Task<PaginationResult<HaircutDto>> GetAllHaircutAsync(int pageIndex, int pageSize);
        Task<HaircutDto> GetHaircut(Guid id);
        Task<bool> UpdateHaircut(HaircutDTQ haircutDtq);
        Task<bool> DesactiveHaircut(Guid id);

    }
}
