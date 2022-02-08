using MediatR;
using ProductStore.API.Models.Request;
using ProductStore.API.Models.Response;

namespace ProductStore.API.Commands
{
    public class SetProductRatingCommand : IRequest<ProductRatingResponse>
    {
        public ProductRatingRequest? RatingRequest { get; set; }
    }
}
