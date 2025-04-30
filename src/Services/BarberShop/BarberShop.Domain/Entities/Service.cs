using BarberShop.Core;

namespace BarberShop.Domain
{

    public class Service : Entity
    {
        public Service() { }
        public Service(string customer, Guid haircutId, string userId)
        {
            Customer = customer;
            HaircutId = haircutId;
            UserId = userId;
        }

        public string Customer { get; private set; }
        public Guid HaircutId { get; private set; }
        public string UserId { get; private set; }
        public User User { get; set; }
        public Haircut Haircut { get; set; }
    }
}
