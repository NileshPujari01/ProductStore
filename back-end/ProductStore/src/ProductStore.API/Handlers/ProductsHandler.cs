using AutoMapper;
using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Queries;
using ProductStore.Application.Interfaces;

namespace ProductStore.API.Handlers
{
    public class ProductsHandler : IRequestHandler<ProductsQuery, ProductsResult>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductsHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductsResult> Handle(ProductsQuery request, CancellationToken cancellationToken)
        {
            var dataResponse = await _dataService.GetProducts();
            var response = _mapper.Map<ProductsResult>(dataResponse);
            return response;
        }
    }
}