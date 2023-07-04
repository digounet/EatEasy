using EatEasy.Domain.Enums;
using EatEasy.Domain.Models;
using EatEasy.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;

namespace EatEasy.Services.API.Configurations
{
    public static class IdentityConfig
    {

        public static void AddAuthenticationConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<EatEasyContext>()
                .AddRoles<IdentityRole>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequiredLength = 6;
                options.User.RequireUniqueEmail = true;
            });

            services.AddAuthorization(options =>
            {
                foreach (var role in UserRoles.ROLES)
                {
                    options.AddPolicy(role,
                        authBuilder =>
                        {
                            authBuilder.RequireRole(role);
                        });
                }
            });
        }
    }
}
