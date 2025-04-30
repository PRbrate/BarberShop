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


        //public static ServiceDTO Map(this Service Service) => new
        //    (Service.Id,  Service.Status, Service.PriceId, Service.UserId);

        public static Service Map(this ScheduleDTQ scheduleDTQ) => new Service
            (scheduleDTQ.Customer, scheduleDTQ.HaircutId, scheduleDTQ.UserId );

        //public static List<ServiceDTO> Map(this ICollection<Service> Services) => Services.Select(Service => Service.Map()
        //).ToList();
    }
}
