using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions;
using ProductStore.Infrastructure.Persistence;
using ProductStore.Infrastructure.Repositories.Base;

namespace ProductStore.Infrastructure.Repositories
{
    public class ProductImagesRepository : RepositoryBase<ProductImagesEntity, ProductStoreDataContext>, IProductImagesRepository
    {
        public ProductImagesRepository(ProductStoreDataContext dbContext) : base(dbContext)
        {
        }
    }
}
