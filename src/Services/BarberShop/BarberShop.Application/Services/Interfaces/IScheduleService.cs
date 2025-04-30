namespace BarberShop.Application
{
    public interface IScheduleService
    {
        Task<bool> Create(ScheduleDTQ scheduleDTQ);
    }
}
