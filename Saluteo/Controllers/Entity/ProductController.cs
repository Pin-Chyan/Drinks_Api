namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;

        public ProductController(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProduct()
        {
            var products = _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var product = new Product
            {
                // Barcode validation
                Barcode = productDto.Barcode,
                ProductName = productDto.ProductName,
                ProductPrice = productDto.ProductPrice,
                ProductCategoryId = productDto.ProductCategoryId,
                CountryId = productDto.CountryId,
                CurrencyId = productDto.CurrencyId,
            };

            _productRepository.InsertAsync(product);

            return Ok(product);
        }
    }
}
