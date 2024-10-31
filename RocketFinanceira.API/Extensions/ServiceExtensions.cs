using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Infra.Data;

namespace RocketFinanceira.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RocketFinanceiraDbContext>(options =>
                options.UseNpgsql(connectionString));
        }
    }
}
