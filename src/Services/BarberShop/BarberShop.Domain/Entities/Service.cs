using BarberShop.Core;

namespace BarberShop.Domain
{
    public class Service : Entity
    {
        public string Customer { get; set; }
        public Guid HaircutId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Haircut Haircut { get; set; }
    }
}
