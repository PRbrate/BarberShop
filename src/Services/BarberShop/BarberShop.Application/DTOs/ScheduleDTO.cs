namespace BarberShop.Application
{
    public record ScheduleDTO(Guid Id, string Customer, Guid HaircutId, string UserId, EntityDTO User, EntityDTO Haircut);
}
