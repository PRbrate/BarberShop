namespace BarberShop.Api.Controllers.v1
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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
        public async Task<IActionResult> CreateHaircut(HaircutDTQ haircutDtq)
        {
            var userId = User.GetUserId();


            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            haircutDtq.UserId = userId;

            var sucess = await _haircutService.CreateHaircut(haircutDtq);

            if (!sucess) NotifyError("Erro ao Cadastrar Corte");

            return CustomResponse(haircutDtq);

        }

        [HttpGet("AllHaircut")]
        public async Task<IActionResult> GetAllHaircuts(int pageIndex = 1, int pageSize = 5)
        {


            var sucess = await _haircutService.GetAllHaircutAsync(pageIndex, pageSize);

            return CustomResponse(sucess);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircut(Guid id)
        {

            var sucess = await _haircutService.GetHaircut(id);

            if (sucess == null) NotifyError("Erro ao buscar Corte");

            return CustomResponse(sucess);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHaircut(Guid id)
        {


            var sucess = await _haircutService.DeleteHaircut(id);

            if (!sucess) NotifyError("Erro ao deletar Corte");

            return CustomResponse(sucess);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHaircut(Guid id,HaircutDTQ haircutDtq)
        {

            haircutDtq.Id = id;

            var sucess = await _haircutService.UpdateHaircut(haircutDtq);

            if (!sucess) NotifyError("Erro ao atualizar Corte");

            return CustomResponse(sucess);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> DesactiveHaircut(Guid id)
        {

            var sucess = await _haircutService.DesactiveHaircut(id);

            if (!sucess) NotifyError("Erro ao desativar Corte");

            return CustomResponse(sucess);
        }
    }
}
