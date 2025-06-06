﻿using BarberShop.Core;

namespace BarberShop.Domain
{
    public class Haircut : Entity
    {
        public Haircut()
        {
            Services = [];
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
