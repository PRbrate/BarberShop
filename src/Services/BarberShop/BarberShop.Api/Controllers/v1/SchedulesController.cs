namespace BarberShop.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ApiControllerBase
    {
       private readonly IScheduleService  _scheduleService;
        public SchedulesController(INotifier notifier, IUser appUser, IScheduleService scheduleService) : base(notifier, appUser)
        {
            _scheduleService = scheduleService;
        }
    }
}
