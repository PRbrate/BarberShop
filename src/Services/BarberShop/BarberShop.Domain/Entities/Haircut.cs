using BarberShop.Core.Entities;

namespace BarberShop.Domain.Entities
{
    public class Haircut : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }

    }
}
