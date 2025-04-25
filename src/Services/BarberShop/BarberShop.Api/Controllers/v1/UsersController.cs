using BarberShop.Application.Services.Interfaces;
using BarberShop.Core.Base;
using BarberShop.Core.Base.Interfaces;
using BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly INotifier _notifier;
        private readonly UserManager<User> _userManager;

        public UsersController(INotifier notifier, IUser user,IUserService userService): base(notifier, user)
        {
            _userService = userService;
        }


        //[HttpPost("AlterarSenhaUsuario")]
        //[ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        //[ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        //public async Task<ActionResult> AlterarSenha([FromBody] ResetPasswordDTO resetPassword)
        //{
        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    var user = await _userManager.FindByEmailAsync(resetPassword.Email);

        //    if (user != null)
        //    {
        //        await _userManager.AddPasswordAsync(user, resetPassword.Senha);
        //    }

        //    await RegistrarLog("Patrimonio", $"Redefiniu a Senha - {user.Nome}");
        //    return CustomResponse(await _userManager.HasPasswordAsync(user));
        //}
    }
}
