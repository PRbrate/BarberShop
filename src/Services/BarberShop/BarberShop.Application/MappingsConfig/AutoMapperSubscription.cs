using BarberShop.Domain.Entities;

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


        public static SubscriptionDTO Map(this Subscription subscription) => new
            (subscription.Id,  subscription.Status, subscription.PriceId, subscription.UserId);

        public static List<SubscriptionDTO> Map(this ICollection<Subscription> subscriptions) => subscriptions.Select(subscription => subscription.Map()
        ).ToList();
    }
}
