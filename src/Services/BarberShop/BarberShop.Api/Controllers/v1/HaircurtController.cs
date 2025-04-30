using BarberShop.Application;

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

        [HttpGet("AllHaircut")]
        public async Task<IActionResult> GetAllHaircuts(int pageIndex = 1, int pageSize = 5)
        {
            var userId = User.GetUserId();

            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            var sucess = await _haircutService.GetAllHaircutAsync(userId, pageIndex, pageSize);

            return CustomResponse(sucess);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircut(Guid id)
        {
            var userId = User.GetUserId();


            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            var sucess = await _haircutService.GetHaircut(id, userId);

            if (sucess == null) NotifyError("Erro ao buscar Corte");

            return CustomResponse(sucess);

        }
    }
}
