using BarberShop.Domain;

namespace BarberShop.Application
{
    public static class AutoMapperSubscription
    {
        public static Subscription Map(this SubscriptionDTO SubscriptionDto) => new Subscription
        {
            Id = SubscriptionDto.Id,
            PriceId = SubscriptionDto.PriceId,
            Status = SubscriptionDto.Status,
            UserId = SubscriptionDto.UserId
        };


        public static Subscription Map(this SubscriptionDtq subscriptionDtq) => new Subscription
        {
            PriceId = subscriptionDtq.PriceId,
            Status = subscriptionDtq.Status,
            UserId = subscriptionDtq.UserId,
        };

        public static SubscriptionDTO Map(this Subscription subscription) => new
            (subscription.Id, subscription.Status, subscription?.PriceId, subscription.UserId);

        public static List<SubscriptionDTO> Map(this ICollection<Subscription> subscriptions) => subscriptions.Select(subscription => subscription.Map()
        ).ToList();
    }
}
