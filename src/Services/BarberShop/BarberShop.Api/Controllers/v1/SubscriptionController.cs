namespace BarberShop.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SubscriptionController : ApiControllerBase
    {
        private readonly IUserService _userService;
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(INotifier notifier, IUser user, IUserService userService, ISubscriptionService subscriptionService) : base(notifier, user)
        {
            _userService = userService;
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscription(SubscriptionDtq subscriptionDtq)
        {
            var userId = User.GetUserId();


            if (string.IsNullOrEmpty(userId))
                NotifyError("User ID not found.");

            subscriptionDtq.UserId = userId;

            var sucess = await _subscriptionService.CreateSubscription(subscriptionDtq);

            if (!sucess) NotifyError("Erro ao Cadastrar Corte");

            return CustomResponse(subscriptionDtq);

        }
    }
}
