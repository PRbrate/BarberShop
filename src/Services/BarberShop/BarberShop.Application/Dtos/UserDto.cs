using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Dtos
{
    public record UserDto(Guid id, string Name, string email, string adress, string password);
}
