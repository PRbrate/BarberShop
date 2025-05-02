using BarberShop.Domain;

namespace BarberShop.Application
{
    public static class AutoMapperSchedule
    {
        //public static Service Map(this ServiceDTO ServiceDto) => new Service
        //{
        //    Id = ServiceDto.Id,
        //    PriceId = ServiceDto.PriceId,
        //    Status = ServiceDto.Status,
        //    UserId = ServiceDto.UserId
        //};


        public static ScheduleDTO Map(this Service service)
        {
            var userId = Guid.TryParse(service.User?.Id, out var parsedUserId) ? parsedUserId : Guid.Empty;
            var userName = service.User?.Name ?? string.Empty;

            var haircutId = service.Haircut?.Id ?? Guid.Empty;
            var haircutName = service.Haircut?.Name ?? string.Empty;

            return new ScheduleDTO(
                service.Id,
                service.Customer,
                service.HaircutId,
                service.User?.Id ?? string.Empty,
                new EntityDTO(userId, userName),
                new EntityDTO(haircutId, haircutName)
            );
        }


        public static Service Map(this ScheduleDTQ scheduleDTQ) => new Service
            (scheduleDTQ.Customer, scheduleDTQ.HaircutId, scheduleDTQ.UserId);

        public static List<ScheduleDTO> Map(this ICollection<Service> Services) => Services.Select(Service => Service.Map()
        ).ToList();
    }
}
