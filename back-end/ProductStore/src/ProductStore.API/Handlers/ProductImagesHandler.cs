using AutoMapper;
using MediatR;
using ProductStore.API.Models;
using ProductStore.API.Queries;
using ProductStore.Application.Interfaces;

namespace ProductStore.API.Handlers
{
    public class ProductImagesHandler : IRequestHandler<ProductImagesQuery, ProductImagesResult>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public ProductImagesHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }

        public async Task<ProductImagesResult> Handle(ProductImagesQuery request, CancellationToken cancellationToken)
        {
            var dataResponse = await _dataService.GetProductImages();
            var response = _mapper.Map<ProductImagesResult>(dataResponse);
            return response;
        }
    }
}