namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionClientClaimedController : ControllerBase
    {
        private readonly PromotionClientClaimedService _promotionClientClaimedService;

        public PromotionClientClaimedController(PromotionClientClaimedService promotionClientClaimedService)
        {
            _promotionClientClaimedService = promotionClientClaimedService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionClientClaimed>>> GetAllPromotionClientClaims()
        {
            var claimedItems = await _promotionClientClaimedService.GetAllPromotionClientClaimsAsync();

            return Ok(claimedItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionClientClaimed>> GetPromotionClientClaimedById(long id)
        {
            var promotionClientClaimed = await _promotionClientClaimedService.GetPromotionClientClaimedByIdAsync(id);
            if (promotionClientClaimed == null)
            {
                return NotFound();
            }

            return Ok(promotionClientClaimed);
        }

        [HttpPost]
        public async Task<ActionResult<PromotionClientClaimed>> CreatePromotionClientClaimed([FromBody] PromotionClientClaimedDto promotionClientClaimedDto)
        {
            var createdPromotionClientClaimed = await _promotionClientClaimedService.CreatePromotionClientClaimedAsync(promotionClientClaimedDto);
            if (createdPromotionClientClaimed == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdPromotionClientClaimed);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionClientClaimed>> UpdatePromotionClientClaimed(long id, [FromBody] PromotionClientClaimedDto updatedPromotionClientClaimedDto)
        {
            var updatedPromotionClientClaimed = await _promotionClientClaimedService.UpdatePromotionClientClaimedAsync(id, updatedPromotionClientClaimedDto);
            if (updatedPromotionClientClaimed == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotionClientClaimed);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotionClientClaimed(long id)
        {
            var isDeleted = await _promotionClientClaimedService.DeletePromotionClientClaimedAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
