using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BarberShop.Api.ApiConfig
{
    public static class IdentifyConfig
    {
        public static WebApplicationBuilder AddIdentityConfig(this WebApplicationBuilder builder)
        {


            var key = Encoding.ASCII.GetBytes("BarberShopApi@Erik&Paulo,2025<Started=April.Paulo=>Developer&&Erik=>TechLead>");
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                };
            });

            builder.Services.AddAuthorization(x =>
            {
                x.AddPolicy("authorize", policy =>
                policy.RequireRole("admin"));
            });

            return builder;

        }
    }
}