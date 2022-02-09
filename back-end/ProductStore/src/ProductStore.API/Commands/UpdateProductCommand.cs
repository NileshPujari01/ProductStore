using MediatR;
using ProductStore.API.Models.Request;
using ProductStore.API.Models.Response;

namespace ProductStore.API.Commands
{
    public class UpdateProductCommand : IRequest<ProductApiResponse>
    {
        public ProductApiRequest? ProductRequest { get; set; }
    }
}
