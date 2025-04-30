using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Dtos
{
    public record HaircutDto(Guid Id, string Name, double Price, string UserId, bool Status);
}
