using EatEasy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace EatEasy.Services.API.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));


            var conStrBuilder = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("DefaultConnection"))
            {
                Password = configuration["DbPassword"],
                Username = configuration["DbUser"],
                Host = configuration["DbServer"],
                Port = 5432,
                Database = configuration["DbName"]
            };

            services.AddDbContext<EatEasyContext>(options =>
                options.UseNpgsql(conStrBuilder.ConnectionString));
        }
    }
}
