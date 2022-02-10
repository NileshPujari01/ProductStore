using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Models.Request;

namespace ProductStore.API.Queries
{
    public class ProductCategoryQuery : IRequest<ProductCategoryResult>
    {
        public CategoryRequest Request { get; set; }
    }
}
