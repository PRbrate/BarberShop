using Microsoft.AspNetCore.Identity;

namespace BarberShop.Domain
{
    public class User : IdentityUser
    {
        public User()
        {
            Subscriptions = [];
            Haircuts = [];
            Services = [];
        }
        public string Name { get; set; }
        public string Address { get; set; }


        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Haircut> Haircuts { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}
