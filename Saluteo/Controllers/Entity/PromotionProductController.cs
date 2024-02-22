namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionProductController : ControllerBase
    {
        private readonly IGenericRepository<PromotionProduct> _promotionProductRepository;

        public PromotionProductController(IGenericRepository<PromotionProduct> promotionProductRepository)
        {
            _promotionProductRepository = promotionProductRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionProduct>> GetAllPromotionProducts()
        {
            var promotionProducts = _promotionProductRepository.GetAllAsync();
            return Ok(promotionProducts);
        }

        [HttpPost]
        public ActionResult CreatePromotionProduct([FromBody] PromotionProductDto promotionProductDto)
        {
            if (promotionProductDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotionProduct = new PromotionProduct
            {
                PromotionId = promotionProductDto.PromotionId,
                ProductId = promotionProductDto.ProductId
            };

            _promotionProductRepository.InsertAsync(promotionProduct);

            return Ok(promotionProduct);
        }
    }
}
