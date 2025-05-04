using BarberShop.Application.Services;
using BarberShop.Data;

namespace BarberShop.Api.ApiConfig
{
    public static class BarberShopServiceLocator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region services
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddScoped<IHaircutService, HaircutService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            #endregion

            #region repositories
            services.AddScoped<BarberShopContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IHaircutRepository, HaircutRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

            #endregion
        }
    }
}
