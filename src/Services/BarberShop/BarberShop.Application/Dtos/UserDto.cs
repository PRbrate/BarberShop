using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Dtos
{
    public record UserDto(string id, string Name, string Email, string Address, string Password);
}
