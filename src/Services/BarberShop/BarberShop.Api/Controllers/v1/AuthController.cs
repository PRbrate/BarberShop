using BarberShop.Application.Dtos;
using BarberShop.Application.MappingsConfig;
using BarberShop.Core.Base;
using BarberShop.Core.Base.Interfaces;
using BarberShop.Data.Repositories.Interfaces;
using BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarberShop.Api.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        public readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepositoy;
        private readonly JwtSettings _jwtSettings;

        public AuthController(SignInManager<User> signInManager, IUserRepository userRepositoy, IOptions<JwtSettings> jwtSettings, INotifier notifier, IUser user) : base(notifier, user)
        {
            _signInManager = signInManager;
            _userRepositoy = userRepositoy;
            _jwtSettings = jwtSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = AutoMapperUser.Map(registerUser);

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                NotifyError(error.Description);
            }
            return CustomResponse();

        } 

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {

                return CustomResponse(await GenerateJwt(loginUser.Email));
            }
            if (result.IsLockedOut)
            {
                NotifyError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            NotifyError("Usuário ou senha incorretos");
            return CustomResponse();
        }


        private async Task<string> GenerateJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString()),

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Emissor,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            var encodedToken = tokenHandler.WriteToken(token);

            return encodedToken;
        }

    }
}
