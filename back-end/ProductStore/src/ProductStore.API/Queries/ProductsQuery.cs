using MediatR;
using ProductStore.API.Models;

namespace ProductStore.API.Queries
{
    public class ProductsQuery : IRequest<ProductsResult>
    {
    }
}