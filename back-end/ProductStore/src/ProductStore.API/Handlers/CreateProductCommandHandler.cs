using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.API.Models.Response;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models.Request;

namespace ProductStore.API.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductApiResponse>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductApiResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<ProductRequest>(request.ProductRequest);
            var dbresponse = await _dataService.CreateProduct(productRequest);
            var response = _mapper.Map<ProductApiResponse>(dbresponse);

            return response;
        }
    }
}
