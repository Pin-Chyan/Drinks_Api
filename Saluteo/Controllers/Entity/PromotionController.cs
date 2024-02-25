namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly PromotionService _promotionService;

        public PromotionController(PromotionService PromotionService)
        {
            _promotionService = PromotionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Promotion>>> GetAllPromotiones()
        {
            var promotions = await _promotionService.GetAllPromotionsAsync();

            return Ok(promotions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetPromotionById(long id)
        {
            var promotion = await _promotionService.GetPromotionByIdAsync(id);
            if (promotion == null)
            {
                return NotFound();
            }

            return Ok(promotion);
        }

        [HttpPost]
        public async Task<ActionResult<Promotion>> CreatePromotion([FromBody] PromotionDto promotionDto)
        {
            var createdPromotion = await _promotionService.CreatePromotionAsync(promotionDto);
            if (createdPromotion == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdPromotion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Promotion>> UpdatePromotion(long id, [FromBody] PromotionDto updatedPromotionDto)
        {
            var updatedPromotion = await _promotionService.UpdatePromotionAsync(id, updatedPromotionDto);
            if (updatedPromotion == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotion);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotion(long id)
        {
            var isDeleted = await _promotionService.DeletePromotionAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
