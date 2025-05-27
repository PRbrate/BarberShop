namespace BarberShop.Api.Controllers.v1
{

    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class HaircurtsController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHaircutService _haircutService;
        public HaircurtsController(INotifier notifier, IUser user, IUserService userService, IHaircutService haircutService) : base(notifier, user)
        {
            _userService = userService;
            _haircutService = haircutService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHaircut(HaircutDTQ haircutDtq)
        {
            haircutDtq.UserId = UserId;

            var sucess = await _haircutService.CreateHaircut(haircutDtq);


            return CustomResponse(haircutDtq);

        }

        [HttpGet("AllHaircut")]
        public async Task<IActionResult> GetAllHaircuts(bool status)
        {
            var userId = UserId;
            var sucess = await _haircutService.GetAllHaircutAsync(userId, status);

            return CustomResponse(sucess);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHaircut(Guid id)
        {

            var sucess = await _haircutService.GetHaircut(id);

            return CustomResponse(sucess);

        }

        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var count =  _haircutService.GetCount(UserId);

            return CustomResponse(count);

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

        [HttpPost("Status/{id}")]
        public async Task<IActionResult> DesactiveHaircut(Guid id)
        {

            var sucess = await _haircutService.DesactiveHaircut(id);

            if (!sucess) NotifyError("Erro ao desativar Corte");

            return CustomResponse(sucess);
        }
    }
}
