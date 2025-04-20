using BarberShop.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Api.ApiConfig
{
    public static class DbContextConfig
    {
        public static WebApplicationBuilder AddDbContextConfig(this WebApplicationBuilder builder)
        {
            //var connectionStr = Environment.GetEnvironmentVariable("CONNECTION_STRING");
            builder.Services.AddDbContext<BarberShopContext>(opt => opt.UseNpgsql((builder.Configuration.GetConnectionString("Connection"))));
            return builder;
        }
    }
}
