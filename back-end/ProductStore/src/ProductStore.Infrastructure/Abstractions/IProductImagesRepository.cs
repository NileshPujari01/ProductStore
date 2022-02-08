using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions.Base;

namespace ProductStore.Infrastructure.Abstractions
{
    public interface IProductImagesRepository : IAsyncRepository<ProductImagesEntity>
    {
    }
}
