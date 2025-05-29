using BarberShop.Domain;

namespace BarberShop.Application.MappingsConfig
{
    public static class AutoMapperHaircut
    {
        public static Haircut Map(this HaircutDTQ haircutDtq) => new() { 
            Id = haircutDtq.Id,
            Name = haircutDtq.Name,
            Price = haircutDtq.Price,
            UserId = haircutDtq.UserId,
            Status = haircutDtq.Status.HasValue ? haircutDtq.Status.Value : true
        };

        public static HaircutDTO Map(this Haircut haircut) => new
             (haircut.Id, haircut.Name, haircut.Price, haircut.UserId, haircut.Status);


        public static List<HaircutDTO> Map(this ICollection<Haircut> subscriptions) => subscriptions.Select(subscription => subscription.Map()
        ).ToList();
    }
}
