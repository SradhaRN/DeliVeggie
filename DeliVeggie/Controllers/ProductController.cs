using DeliVeggie.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DeliVeggie.Controllers
{
    [ApiController]
    [Route("api/Product/")]
    //[Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var productList = _productService.GetAllProducts();
            if (productList == null)
                return NotFound();
            return Ok(productList);
            
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductDetails(string productId)
        {
            var productList = _productService.GetProductDetails(productId);
            if (productList == null)
                return NotFound();
            return Ok(productList);

        }
    }
}
