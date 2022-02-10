using Microsoft.Extensions.DependencyInjection;
using ProductStore.Infrastructure.Abstractions;
using ProductStore.Infrastructure.Persistence;
using ProductStore.Infrastructure.Repositories;

namespace ProductStore.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddTransient<IProductImagesRepository, ProductImagesRepository>();
            services.AddTransient<IProductsRepository, ProductsRepository>();
            services.AddTransient<IConnectionStringProvider, ConnectionStringProvider>();

            return services;
        }
    }
}
