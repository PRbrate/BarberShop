using BarberShop.Application;
using BarberShop.Core;
using BarberShop.Core.Extensions.Security;
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



            services.AddScoped<IUserService, UserService>();
            #endregion

            #region repositories
            services.AddScoped<BarberShopContext>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
