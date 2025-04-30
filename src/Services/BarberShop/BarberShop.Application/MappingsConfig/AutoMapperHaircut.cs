using BarberShop.Domain;

namespace BarberShop.Application.MappingsConfig
{
    public static class AutoMapperHaircut
    {
        public static Haircut Map(this HaircutDto haircutDto) => new Haircut
        {
            Id = haircutDto.Id,
            Name = haircutDto.Name,
            Price = haircutDto.Price,
            UserId = haircutDto.UserId,
            Status = haircutDto.Status
        };

        public static Haircut Map(this HaircutDTQ haircutDto) => new Haircut
        {
            Id = new Guid(),
            Name = haircutDto.Name,
            Price = haircutDto.Price,
            UserId = haircutDto.UserId,
            Status = true
        };

        public static HaircutDto Map(this Haircut haircut) => new
             (haircut.Id, haircut.Name, haircut.Price, haircut.UserId, haircut.Status);

    }
}
