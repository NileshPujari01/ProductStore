using Microsoft.Extensions.DependencyInjection;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Services;

namespace ProductStore.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IDataService, DataService>();

            return services;
        }
    }
}
