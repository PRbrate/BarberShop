using BarberShop.Data.Context;
using BarberShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BarberShop.Api.ApiConfig
{
    public static class ApiConfig
    {
        public static WebApplicationBuilder AddApiConfig(this WebApplicationBuilder builder)
        {
            builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BarberShopContext>()
                .AddDefaultTokenProviders();

            builder.Services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = true;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
                });

            builder.Services.RegisterServices();

            return builder;
        }

    }
}
