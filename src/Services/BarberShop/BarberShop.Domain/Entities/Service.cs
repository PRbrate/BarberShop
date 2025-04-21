using BarberShop.Core.Entities;

namespace BarberShop.Domain.Entities
{
    public class Service : Entity
    {
        public string Customer { get; set; }
        public Guid Haircut_id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
