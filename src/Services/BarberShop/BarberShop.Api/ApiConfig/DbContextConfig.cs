using BarberShop.Data;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Api.ApiConfig
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            var connectionStr = Environment.GetEnvironmentVariable("CONNECTION");
            builder.Services.AddDbContext<BarberShopContext>(opt => opt.UseNpgsql((connectionStr)));
            return builder;
        }
    }
}
