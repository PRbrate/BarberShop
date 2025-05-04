using BarberShop.Data;

namespace BarberShop.Application.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository, IUserRepository user)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = user;
        }

        public async Task<bool> CreateSubscription(SubscriptionDtq subscriptionDtq)
        {
            var subscription = AutoMapperSubscription.Map(subscriptionDtq);

            var result = await _subscriptionRepository.Create(subscription);

            return result;
        }
    }
}
