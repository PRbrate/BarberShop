using BarberShop.Core.Entities;

namespace BarberShop.Domain.Entities
{
    public class Subscription : Entity
    {
        public bool Status { get; set; }
        public string PriceId { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
