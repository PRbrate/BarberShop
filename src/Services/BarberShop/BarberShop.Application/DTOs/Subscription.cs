namespace BarberShop.Application
{
    public record SubscriptionDTO(Guid Id, bool Status, string PriceId, string UserId);
}
