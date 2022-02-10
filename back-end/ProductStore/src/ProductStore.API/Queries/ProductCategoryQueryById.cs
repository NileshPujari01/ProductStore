using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Models.Request;

namespace ProductStore.API.Queries
{
    public class ProductCategoryQueryById : IRequest<ProductCategoryResult>
    {
        public CategoryRequest Request { get; set; }
    }
}
