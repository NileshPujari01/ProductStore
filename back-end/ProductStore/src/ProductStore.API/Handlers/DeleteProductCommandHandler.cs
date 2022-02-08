using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.Application.Interfaces;

namespace ProductStore.API.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _dataService.DeleteProduct(request.DeleteProduct);
        }
    }
}
