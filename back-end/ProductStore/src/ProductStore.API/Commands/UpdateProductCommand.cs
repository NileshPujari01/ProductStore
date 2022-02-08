using MediatR;
using ProductStore.API.Models.Request;

namespace ProductStore.API.Commands
{
    public class UpdateProductCommand : IRequest<string>
    {
        public ProductApiRequest? ProductRequest { get; set; }
    }
}
