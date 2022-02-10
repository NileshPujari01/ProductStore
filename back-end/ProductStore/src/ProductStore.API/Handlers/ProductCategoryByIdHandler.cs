using AutoMapper;
using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Queries;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models.Request;

namespace ProductStore.API.Handlers
{
    public class ProductCategoryByIdHandler : IRequestHandler<ProductCategoryQueryById, ProductCategoryResult>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductCategoryByIdHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductCategoryResult> Handle(ProductCategoryQueryById request, CancellationToken cancellationToken)
        {
            var categoryRequest = _mapper.Map<ProductCategoryRequest>(request.Request);
            var dataResponse = await _dataService.GetProductCategoryById(categoryRequest);
            var response = _mapper.Map<ProductCategoryResult>(dataResponse);
            return response;
        }
    }
}
