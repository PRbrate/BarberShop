using BarberShop.Core;

namespace BarberShop.Domain
{
    public class Subscription : Entity
    {
        public bool Status { get; set; }
        public string PriceId { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
