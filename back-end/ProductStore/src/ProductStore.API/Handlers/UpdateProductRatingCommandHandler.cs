using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.API.Models.Response;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models.Request;

namespace ProductStore.API.Handlers
{
    public class UpdateProductRatingCommandHandler : IRequestHandler<UpdateProductCommand, ProductApiResponse>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public UpdateProductRatingCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductApiResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<ProductRequest>(request.ProductRequest);
            var dbResponse = await _dataService.UpdateProduct(productRequest);
            var response = _mapper.Map<ProductApiResponse>(dbResponse);

            return response;
        }
    }
}