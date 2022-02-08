using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions;
using ProductStore.Infrastructure.Persistence;
using ProductStore.Infrastructure.Repositories.Base;

namespace ProductStore.Infrastructure.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<ProductCategoryEntity, ProductStoreDataContext>, IProductCategoryRepository
    {
        public ProductCategoryRepository(ProductStoreDataContext dbContext) : base(dbContext)
        {
        }
    }
}
