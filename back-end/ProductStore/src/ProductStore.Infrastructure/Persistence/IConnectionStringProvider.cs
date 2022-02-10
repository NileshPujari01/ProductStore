namespace ProductStore.Infrastructure.Persistence
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
}
