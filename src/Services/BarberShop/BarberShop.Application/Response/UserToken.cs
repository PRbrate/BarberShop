using BarberShop.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Response
{
    public class UserToken
    {
        public string AccessToken { get; set; }
        public UserDTO User { get; set; }
    }
}
