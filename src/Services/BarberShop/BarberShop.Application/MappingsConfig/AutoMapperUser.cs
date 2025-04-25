using BarberShop.Application.Dtos;
using BarberShop.Domain.Entities;

namespace BarberShop.Application.MappingsConfig
{
    public static class AutoMapperUser
    {
        public static User Map(this UserDTO userDto) => new User
        {
            Id = userDto.id,
            Name = userDto.Name,
            Email = userDto.Email,
            Address = userDto.Address
        };

        public static User Map(this RegisterUserDto userDto) => new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            UserName = userDto.Email.Split('@')[0],
            Address = userDto.Address,
            PasswordHash = userDto.Password
        };
        public static UserDTO Map(this User user) => new
            (user.Id, user.Name, user.Email, user.Address, user.Subscriptions);
    }
}
