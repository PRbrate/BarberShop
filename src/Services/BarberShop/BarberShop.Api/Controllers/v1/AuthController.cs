using BarberShop.Application;
using BarberShop.Core;
using BarberShop.Core.Base.Controller;
using BarberShop.Domain;
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
        private readonly JwtSettings _jwtSettings;
        private readonly IUserService _userService;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, IOptions<JwtSettings> jwtSettings, INotifier notifier, IUser user, IUserService userService) : base(notifier, user)
        {
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUser)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            var user = registerUser.Map();

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

            var user = await _userService.GetFindByEmailAsync(loginUser.Email);

            if (user == null)
            {
                NotifyError("Login inválido.");
                return CustomResponse();
            }
            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, true);

            if (result.Succeeded)
                return CustomResponse(await GenerateJwt(user));

            if (result.IsLockedOut)
            {
                NotifyError("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse();
            }

            NotifyError("Usuário ou senha incorretos");
            return CustomResponse();
        }


        private async Task<UserToken> GenerateJwt(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim("Address",user.Address),

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience,
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpireHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);

            var encodedToken = tokenHandler.WriteToken(token);

            var tokenModel = new UserToken
            {
                User = user.Map(),
                AccessToken = encodedToken
            };
            return await Task.FromResult(tokenModel);
        }

    }
}
