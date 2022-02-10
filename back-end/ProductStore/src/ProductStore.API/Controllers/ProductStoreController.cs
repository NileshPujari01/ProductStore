using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductStore.API.Commands;
using ProductStore.API.Models.Request;
using ProductStore.API.Queries;

namespace ProductStore.API.Controllers
{
    [ApiController]
    [Route("ProductStore")]
    public class ProductStoreController : Controller
    {
        private readonly IMediator _mediator;

        public ProductStoreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetProductCategoryById")]
        public async Task<IActionResult> GetProductCategoryById([FromBody] ProductCategoryQueryById categoryRequest)
        {
            var productCategories = await _mediator.Send(categoryRequest);

            return Ok(productCategories);
        }

        [HttpGet]
        [Route("GetProductCategories")]
        public async Task<IActionResult> GetProductCategories()
        {
            var productCategories = await _mediator.Send(new ProductCategoryQuery());

            return Ok(productCategories);
        }

        [HttpGet]
        [Route("GetProductImages")]
        public async Task<IActionResult> GetProductImages()
        {
            var productImages = await _mediator.Send(new ProductImagesQuery());

            return Ok(productImages);
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _mediator.Send(new ProductsQuery());

            return Ok(products);
        }

        [HttpPost]
        [Route("SetProductRating")]
        public async Task<IActionResult> SetProductRating([FromBody] SetProductRatingCommand request)
        {
            var products = await _mediator.Send(request);

            return Ok(products);
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommand request)
        {
            var products = await _mediator.Send(request);

            return Ok(products);
        }

        [HttpPost]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand request)
        {
            var products = await _mediator.Send(request);

            return Ok(products);
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand request)
        {
            var products = await _mediator.Send(request);

            return Ok(products);
        }
    }
}
