namespace BarberShop.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ServicesController : ApiControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public ServicesController(INotifier notifier, IUser appUser, IScheduleService scheduleService) : base(notifier, appUser)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("schedules")]
        public async Task<IActionResult> GetAll()
        {
            var userId = User.GetUserId();

            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            var scheduleDtos = await _scheduleService.GetScheduleByUserId(userId);

            return CustomResponse(scheduleDtos);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ScheduleDTQ scheduleDTQ)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            await _scheduleService.Create(scheduleDTQ);

            return CustomResponse(scheduleDTQ);

        }
        [HttpPost("Finish")]
        public async Task<IActionResult> Finish(EntityDTQ entity)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);

            await _scheduleService.FinishSchedule(User.GetUserId(), entity.Id);

            return CustomResponse(entity);

        }
    }
}
