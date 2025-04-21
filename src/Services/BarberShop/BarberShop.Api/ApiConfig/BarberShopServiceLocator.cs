using BarberShop.Application.Services;
using BarberShop.Application.Services.Interfaces;
using BarberShop.Core.Base;
using BarberShop.Core.Base.Interfaces;
using BarberShop.Data.Repositories;
using BarberShop.Data.Repositories.Interfaces;

namespace BarberShop.Api.ApiConfig
{
    public static class BarberShopServiceLocator
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region repositories
            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserRepository, UserRepository>();

            #endregion
        }
    }
}
