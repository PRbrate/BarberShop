namespace BarberShop.Api.Controllers.v1
{
    [Authorize]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SubscriptionsController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionsController(INotifier notifier, IUser user, IUserService userService, ISubscriptionService subscriptionService) : base(notifier, user)
        {
            _userService = userService;
            _subscriptionService = subscriptionService;
        }

        [HttpGet("check-subscription")]
        public async Task<IActionResult> Check()
        {

            var subscrioption = await _subscriptionService.CheckSubscription(UserId);

            return CustomResponse(subscrioption);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(SubscriptionDtq subscriptionDtq)
        {
            subscriptionDtq.UserId = UserId;

            var sucess = await _subscriptionService.Create(subscriptionDtq);

            if (!sucess) NotifyError("Erro ao Cadastrar Corte");

            return CustomResponse(subscriptionDtq);

        }

    }
}
