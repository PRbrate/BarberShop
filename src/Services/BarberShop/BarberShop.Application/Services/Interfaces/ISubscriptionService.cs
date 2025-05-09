namespace BarberShop.Application
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDTO>> CheckSubscription(string userId);
        Task<bool> Create(SubscriptionDtq subscriptionDtq);
    }
}
