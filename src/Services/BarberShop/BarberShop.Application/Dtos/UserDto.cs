using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Dtos
{
    public record UserDTO(string id, string Name, string Email, string Address, ICollection<Subscription> Subscriptions);
}
