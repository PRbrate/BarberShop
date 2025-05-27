namespace BarberShop.Application
{
    public interface IScheduleService
    {
        Task<bool> Create(ScheduleDTQ scheduleDTQ);
        Task<List<ScheduleDTO>> GetScheduleByUserId(string userId);
        Task FinishSchedule(string userId, Guid scheduleId);
    }
}
