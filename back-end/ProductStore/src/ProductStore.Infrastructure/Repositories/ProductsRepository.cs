using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Abstractions;
using ProductStore.Infrastructure.Persistence;
using ProductStore.Infrastructure.Repositories.Base;

namespace ProductStore.Infrastructure.Repositories
{
    public class ProductsRepository : RepositoryBase<ProductsEntity, ProductStoreDataContext>, IProductsRepository
    {
        public ProductsRepository(ProductStoreDataContext dbContext) : base(dbContext)
        {
        }
    }
}
