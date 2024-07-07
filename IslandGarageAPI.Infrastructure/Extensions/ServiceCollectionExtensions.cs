using IslandGarageAPI.Domain.Interfaces.Repositories;
using IslandGarageAPI.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace IslandGarageAPI.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IVehicleRepository, VehicleRepository>();

            return services;
        }
    }
}
