namespace BarberShop.Application
{
    public interface ISubscriptionService
    {
        Task<bool> CreateSubscription(SubscriptionDtq subscriptionDtq);
    }
}
