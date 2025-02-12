using DonorFlow.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using DonorFlow.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using DonorFlow.Core.Services.AuthService;
using DonorFlow.Infrastructure.Persistence;
using DonorFlow.Infrastructure.Integrations;
using Microsoft.Extensions.DependencyInjection;
using DonorFlow.Core.Integrations.ApiCepIntegration;
using DonorFlow.Infrastructure.Persistence.Repositories;

namespace DonorFlow.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DonorFlowCs");

            services
                .AddDb(connectionString)
                .AddRepositories()
                .AddIntegrations()
                .AddServices();

            return services;
        }

        private static IServiceCollection AddDb(this IServiceCollection services, string? connectionString)
        {
            services.AddDbContext<DonorDbContext>(options =>
              options.UseSqlServer(connectionString, b => b.MigrationsAssembly("DonorFlow.Infrastructure")));

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IBloodStockRepository, BloodStockRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        private static IServiceCollection AddIntegrations(this IServiceCollection services)
        {
            services.AddScoped<IApiCepService, ApiCepIntegration>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddAutoMapper(typeof(MappingService));

            return services;
        }
    }
}
