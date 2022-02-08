using MediatR;
using ProductStore.API.Models.Request;

namespace ProductStore.API.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int DeleteProduct { get; set; }
    }
}
