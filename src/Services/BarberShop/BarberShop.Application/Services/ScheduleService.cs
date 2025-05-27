using BarberShop.Core;
using BarberShop.Data;
using BarberShop.Domain;

namespace BarberShop.Application
{
    public class ScheduleService(IScheduleRepository scheduleRepository, INotifier notifier) : ServiceBase(notifier), IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository = scheduleRepository;

        public async Task<bool> Create(ScheduleDTQ scheduleDTQ)
        {
            var schedule = scheduleDTQ.Map();

            if (!ExecuteVatidation(new ScheduleValidation(), schedule)) return false;

            return await _scheduleRepository.Create(schedule);

        }

        public async Task<List<ScheduleDTO>> GetScheduleByUserId(string userId)
        {
            var schedules = await _scheduleRepository.GetScheduleByUserId(userId);

            return schedules.Map();
        }

        public async Task FinishSchedule(string userId, Guid scheduleId)
        {
            var schedule = await _scheduleRepository.GetId(scheduleId);

            if (schedule == null)
            {
                Notifier("Schedule not found.");
                return;
            }

            schedule.Finish();

            await _scheduleRepository.Update(schedule);
        }
        public void Dispose()
        {
            _scheduleRepository?.Dispose();
        }
    }

}
