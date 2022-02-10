using Microsoft.Extensions.Configuration;

namespace ProductStore.Infrastructure.Persistence
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public IConfiguration Configuration { get; }
        public ConnectionStringProvider(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string GetConnectionString()
        {
            return Configuration.GetConnectionString("ProductStoreConnectionString");
        }
    }
}
