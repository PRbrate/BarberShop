using BarberShop.Application.Dtos;
using BarberShop.Application.MappingsConfig;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Application.Services.OtherServices;
using BarberShop.Core.Entities;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;
using BarberShop.Domain.Entities.Validations.Services;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<bool> CreateUser(UserDto userDto)
        {
            if (!EmailValidatorService.VerifyEmail(userDto.Email) || !PasswordValidatorSerivce.VerifyPassword(userDto.Password) || await _userRepository.EmailUserExists(userDto.Email) == true) return false; 

            var user = AutoMapperUser.Map(userDto);

            user.Password = PasswordCryptographyService.Cryptography(user.Password);
            await _userRepository.Create(user);
            user.Password = "";

            return true;
        }

        public async Task<Response<string>> Authenticate(string email, string password)
        {
            var response = new Response<string>();

            if (!EmailValidatorService.VerifyEmail(email) || !PasswordValidatorSerivce.VerifyPassword(password)) { response.Success = false; return response; }

            var user = await _userRepository.GetByEmailAsync(email);

            if(user.Id == Guid.Empty) { response.Success = false; return response; }

            
            if(!PasswordCryptographyService.VerifyPassword(password, user.Password)){ response.Success = false; return response; }

            var token = TokenService.GenerateToken(user);

            response.Data = token;

            return response;

        }

    }
}
