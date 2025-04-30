namespace BarberShop.Application
{
    public interface IHaircutService 
    {
        Task<bool> CreateHaircut(HaircutDTQ haircutDto);
        Task<bool> DeleteHaircut(Guid haircutId);
        Task<bool> GetAllHaircutAsync();
        Task<bool> GetHaircut(Guid id);
        Task<bool> UpdateHaircut(HaircutDTQ haircutDtq);

    }
}
