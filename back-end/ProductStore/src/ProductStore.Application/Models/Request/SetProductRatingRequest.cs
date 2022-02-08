namespace ProductStore.Application.Models.Request
{
    public class SetProductRatingRequest
    {
        public int ProductId { get; set; }
        public int ProductCategory { get; set; } = 1;
        public int ProductRating { get; set; }
    }
}
