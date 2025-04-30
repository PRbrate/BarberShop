namespace BarberShop.Application
{
    public record HaircutDto(Guid Id, string Name, double Price, string UserId, bool Status);
}
