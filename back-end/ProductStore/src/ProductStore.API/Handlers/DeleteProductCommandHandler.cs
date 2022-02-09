using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.API.Models.Response;
using ProductStore.Application.Interfaces;

namespace ProductStore.API.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ProductDeleteResponse>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductDeleteResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var dbResponse = await _dataService.DeleteProduct(request.DeleteProduct);
            var response = _mapper.Map<ProductDeleteResponse>(dbResponse);
            return response;
        }
    }
}
