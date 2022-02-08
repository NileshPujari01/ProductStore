using AutoMapper;
using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Queries;
using ProductStore.Application.Interfaces;

namespace ProductStore.API.Handlers
{
    public class ProductCategoryHandler : IRequestHandler<ProductCategoryQuery, ProductCategoryResult>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductCategoryHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductCategoryResult> Handle(ProductCategoryQuery request, CancellationToken cancellationToken)
        {
            var dataResponse = await _dataService.GetProductCategories();
            var response = _mapper.Map<ProductCategoryResult>(dataResponse);
            return response;
        }
    }
}
