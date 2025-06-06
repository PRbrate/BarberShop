﻿namespace BarberShop.Api.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
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

            var scheduleDtos = await _scheduleService.GetScheduleByUserId(UserId);

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
