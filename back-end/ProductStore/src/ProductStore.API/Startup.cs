using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductStore.API.Commands;
using ProductStore.API.Handlers;
using ProductStore.API.Mapping;
using ProductStore.API.Queries;
using ProductStore.Application.Extensions;
using ProductStore.Application.Mapping;
using ProductStore.Infrastructure.Extensions;
using ProductStore.Infrastructure.Persistence;
using System.Reflection;

namespace ProductStore.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("Cors", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            }));

            services.AddDbContext<ProductStoreDataContext>(options => 
                options.UseNpgsql(Configuration.GetConnectionString("ProductStoreConnectionString"))
            );
            services.AddMvc(options => { options.EnableEndpointRouting = false; });
            services.AddControllers();
            services.AddAutoMapper(GetMapperProfileAssemblies());

            services.AddInfrastructureServices();
            services.AddApplicationServices();

            services.AddMediatR(typeof(ProductsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SetProductRatingCommandHandler).GetTypeInfo().Assembly);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseMvc();
            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEnumerable<Assembly> GetMapperProfileAssemblies()
        {
            yield return typeof(ProductStoreServiceProfile).GetTypeInfo().Assembly;
            yield return typeof(ProductStoreMapping).GetTypeInfo().Assembly;
        }
    }
}
