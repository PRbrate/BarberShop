using Microsoft.AspNet.Identity.EntityFramework;

namespace BarberShop.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string Password { get; set; }
        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public ICollection<Haircut> Haircuts { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}
