namespace BarberShop.Api.Controllers
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

            var userDTO = await _userService.GetUserById(UserId);

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

    }
}
