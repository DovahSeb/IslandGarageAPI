using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IslandGarageAPI.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();

            return services;
        }
    }
}
