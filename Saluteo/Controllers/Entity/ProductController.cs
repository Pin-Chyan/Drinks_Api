namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProductById(long id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productDto)
        {
            var createdProduct = await _productService.CreateProductAsync(productDto);
            if (createdProduct == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(long id, [FromBody] ProductDto updatedProductDto)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, updatedProductDto);
            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            var isDeleted = await _productService.DeleteProductAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
