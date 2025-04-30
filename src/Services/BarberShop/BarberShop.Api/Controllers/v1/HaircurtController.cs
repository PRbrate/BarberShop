namespace BarberShop.Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HaircurtController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHaircutService _haircutService;
        public HaircurtController(INotifier notifier, IUser user, IUserService userService, IHaircutService haircutService) : base(notifier, user)
        {
            _userService = userService;
            _haircutService = haircutService;   
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircut(HaircutDTQ haircutDto)
        {
            var userId = User.GetUserId();


            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            haircutDto.UserId = userId;

            var sucess = await _haircutService.CreateHaircut(haircutDto);

            if (!sucess) NotifyError("Erro ao Cadastrar Corte");

            return CustomResponse(haircutDto);

        }
    }
}
