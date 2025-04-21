using BarberShop.Application.Dtos;
using BarberShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.MappingsConfig
{
    public static class AutoMapperUser
    {
        public static User Map(this UserDto userDto) => new User
        {
            Id = userDto.id,
            Name = userDto.Name,
            Email = userDto.email,
            Adress = userDto.adress,
            Password = userDto.password
        };

        public static UserDto Map(this User user) => new
            (user.Id, user.Name, user.Email, user.Adress, user.Password);
    }
}
