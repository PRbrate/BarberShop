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

        public async Task<List<SubscriptionDTO>> CheckSubscription(string userId)
        {
            var subscriptions = await _subscriptionRepository.GetSubscriptionsFromUser(userId);

            var map = AutoMapperSubscription.Map(subscriptions);

            return map;
        }

        public async Task<bool> Create(SubscriptionDtq subscriptionDtq)
        {
            var subscription = AutoMapperSubscription.Map(subscriptionDtq);

            var result = await _subscriptionRepository.Create(subscription);

            return result;
        }
    }
}
