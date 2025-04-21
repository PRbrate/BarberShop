using BarberShop.Application.Dtos;
using BarberShop.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            try
            {
                var user = await _userService.CreateUser(userDto);

                if (user == false) return BadRequest("Não foi possivel Criar o usuário, e-mail ou senha inválidos");

                return Ok();
               
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(string email, string password)
        {
            try
            {
                var user = await _userService.Authenticate(email, password);

                if (user.Success == false) return BadRequest("Não foi possivel autenticar o usuário, e-mail ou senha inválidos");

                return Ok(user);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
