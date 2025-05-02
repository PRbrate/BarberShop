using BarberShop.Core;

namespace BarberShop.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
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

            var userDTO = await _userService.GetUserById(userId);

            if (userDTO == null)
                NotifyError("User not found.");

            return CustomResponse(userDTO);

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(string id, UserDTQ user)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            if (id != user.Id)
            {
                NotifyError("Incorrect Id");
                return CustomResponse(user);
            }

            bool success = await _userService.Update(user);

            if (!success)
                NotifyError("Failed to update user");


            var userDTO = await _userService.GetUserById(id);

            return CustomResponse(userDTO);
        }

        [HttpGet("check-subscription")]
        public async Task<IActionResult> CheckSupscription()
        {

            var userId = User.GetUserId();

            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            var subscrioption = await _userService.CheckSubscription(userId);

            if (subscrioption == null) NotifyError("Não existe inscrição para o usuário");

            return CustomResponse(subscrioption);
        }

    }
}
