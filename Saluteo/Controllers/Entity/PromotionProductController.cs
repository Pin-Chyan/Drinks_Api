namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionProductController : ControllerBase
    {
        private readonly PromotionProductService _promotionProductService;

        public PromotionProductController(PromotionProductService PromotionProductService)
        {
            _promotionProductService = PromotionProductService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionProduct>>> GetAllPromotionProducts()
        {
            var PromotionProductPeriods = await _promotionProductService.GetAllPromotionProductsAsync();

            return Ok(PromotionProductPeriods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionProduct>> GetPromotionProductById(long id)
        {
            var promotionProductPeriod = await _promotionProductService.GetPromotionProductByIdAsync(id);
            if (promotionProductPeriod == null)
            {
                return NotFound();
            }

            return Ok(promotionProductPeriod);
        }

        [HttpPost]
        public async Task<ActionResult<PromotionProduct>> CreatePromotionProduct([FromBody] PromotionProductDto promotionProductDto)
        {
            var createdPromotionProduct = await _promotionProductService.CreatePromotionProductAsync(promotionProductDto);
            if (createdPromotionProduct == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdPromotionProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionProduct>> UpdatePromotionProduct(long id, [FromBody] PromotionProductDto updatedPromotionProductDto)
        {
            var updatedPromotionProduct = await _promotionProductService.UpdatePromotionProductAsync(id, updatedPromotionProductDto);
            if (updatedPromotionProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotionProduct);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotionProduct(long id)
        {
            var isDeleted = await _promotionProductService.DeletePromotionProductAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
