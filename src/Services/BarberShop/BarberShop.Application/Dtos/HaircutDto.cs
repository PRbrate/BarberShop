namespace BarberShop.Application
{
    public record HaircutDTO(Guid Id, string Name, double Price, string UserId, bool Status);
}
