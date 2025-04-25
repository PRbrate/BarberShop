using Microsoft.AspNetCore.Identity;

namespace BarberShop.Domain.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            Subscriptions = new List<Subscription>();
            Haircuts = new List<Haircut>();
            Services = new List<Service>();
        }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Haircut> Haircuts { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}
