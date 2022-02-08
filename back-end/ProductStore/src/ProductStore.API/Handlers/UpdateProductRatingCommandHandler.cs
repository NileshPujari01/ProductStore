using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models.Request;

namespace ProductStore.API.Handlers
{
    public class UpdateProductRatingCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public UpdateProductRatingCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productRequest = _mapper.Map<ProductRequest>(request.ProductRequest);
            var response = await _dataService.UpdateProduct(productRequest);
            return response;
        }
    }
}