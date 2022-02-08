using MediatR;
using ProductStore.API.Models.Request;

namespace ProductStore.API.Commands
{
    public class CreateProductCommand : IRequest<string>
    {
        public ProductApiRequest? ProductRequest { get; set; }
    }
}
