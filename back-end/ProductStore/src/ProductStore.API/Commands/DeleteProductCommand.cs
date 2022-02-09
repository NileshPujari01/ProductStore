using MediatR;
using ProductStore.API.Models.Request;
using ProductStore.API.Models.Response;

namespace ProductStore.API.Commands
{
    public class DeleteProductCommand : IRequest<ProductDeleteResponse>
    {
        public int DeleteProduct { get; set; }
    }
}
