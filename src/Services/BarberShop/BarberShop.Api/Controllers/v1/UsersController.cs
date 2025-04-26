using BarberShop.Application;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Core.Base;
using BarberShop.Core.Base.Interfaces;
using BarberShop.Core.Extensions.Security;
using BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BarberShop.Api.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly INotifier _notifier;
        private readonly UserManager<User> _userManager;

        public UsersController(INotifier notifier, IUser user, IUserService userService) : base(notifier, user)
        {
            _userService = userService;
        }


        [HttpGet("user-detail")]
        public async Task<IActionResult> GetUserDetail()
        {
            var userId = User.GetUserId();

            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            var userDTO = await _userService.GetUserFromId(userId);

            if (userDTO == null)
                NotifyError("User not found.");

            return CustomResponse(userDTO);

        }

    }
}
