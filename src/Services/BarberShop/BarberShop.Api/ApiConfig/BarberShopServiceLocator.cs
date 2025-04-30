using BarberShop.Application;
using BarberShop.Application.Services;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Core;
using BarberShop.Core.Extensions.Security;
using BarberShop.Data;
using BarberShop.Data.Repositories;
using BarberShop.Data.Repositories.Interfaces;

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
            #endregion

            #region repositories
            services.AddScoped<BarberShopContext>();
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHaircutRepository, HaircutRepository>();

            #endregion
        }
    }
}
