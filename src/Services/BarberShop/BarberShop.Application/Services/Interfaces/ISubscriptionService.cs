using BarberShop.Application.DTQ;

namespace BarberShop.Application.Services.Interfaces
{
    public interface ISubscriptionService
    {
        Task<bool> CreateSubscription(SubscriptionDtq subscriptionDtq);
    }
}
