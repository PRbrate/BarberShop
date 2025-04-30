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

            if (!ExecutarValidacao(new ScheduleValidation(), schedule)) return false;


            return await _scheduleRepository.Create(schedule);

        }

        public void Dispose()
        {
            _scheduleRepository.Dispose();
        }
    }

}
