using Microsoft.EntityFrameworkCore;
using RocketFinanceira.Application.Interfaces;
using RocketFinanceira.Application.Interfaces.Repositories;
using RocketFinanceira.Infra;
using RocketFinanceira.Infra.Data;
using RocketFinanceira.Infra.Repositories;

namespace RocketFinanceira.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<RocketFinanceiraDbContext>(options =>
                options.UseNpgsql(connectionString));
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
