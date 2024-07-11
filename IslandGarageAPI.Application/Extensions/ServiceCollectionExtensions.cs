using IslandGarageAPI.Application.Interfaces;
using IslandGarageAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IslandGarageAPI.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IVehicleImageService, VehicleImageService>();

            return services;
        }
    }
}
