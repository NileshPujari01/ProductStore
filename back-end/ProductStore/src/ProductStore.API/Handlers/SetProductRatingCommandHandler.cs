using AutoMapper;
using MediatR;
using ProductStore.API.Commands;
using ProductStore.API.Models.Response;
using ProductStore.Application.Interfaces;
using ProductStore.Application.Models.Request;

namespace ProductStore.API.Handlers
{
    public class SetProductRatingCommandHandler : IRequestHandler<SetProductRatingCommand, ProductRatingResponse>
    {
        private readonly IDataService _dataService;
        private readonly IMapper _mapper;

        public SetProductRatingCommandHandler(IDataService dataService, IMapper mapper)
        {
            _dataService = dataService;
            _mapper = mapper;
        }
        
        public async Task<ProductRatingResponse> Handle(SetProductRatingCommand request, CancellationToken cancellationToken)
        {
            var ratingRequest = _mapper.Map<SetProductRatingRequest>(request.RatingRequest);
            var serviceResponse = await _dataService.SetProductRating(ratingRequest);
            var response = _mapper.Map<ProductRatingResponse>(serviceResponse);
            return response;
        }
    }
}
