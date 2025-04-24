using BarberShop.Core.Entities;

namespace BarberShop.Domain.Entities
{
    public class Service : Entity
    {
        public string Customer { get; set; }
        public Guid Haircut_id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
