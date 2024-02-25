namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionPeriodController : ControllerBase
    {
        private readonly PromotionPeriodService _promotionPeriodService;

        public PromotionPeriodController(PromotionPeriodService PromotionPeriodService)
        {
            _promotionPeriodService = PromotionPeriodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionPeriod>>> GetAllPromotionPeriods()
        {
            var promotionPeriodPeriods = await _promotionPeriodService.GetAllPromotionPeriodsAsync();

            return Ok(promotionPeriodPeriods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionPeriod>> GetPromotionPeriodById(long id)
        {
            var promotionPeriodPeriod = await _promotionPeriodService.GetPromotionPeriodByIdAsync(id);
            if (promotionPeriodPeriod == null)
            {
                return NotFound();
            }

            return Ok(promotionPeriodPeriod);
        }

        [HttpPost]
        public async Task<ActionResult<PromotionPeriod>> CreatePromotionPeriod([FromBody] PromotionPeriodDto promotionPeriodDto)
        {
            var createdPromotionPeriod = await _promotionPeriodService.CreatePromotionPeriodAsync(promotionPeriodDto);
            if (createdPromotionPeriod == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdPromotionPeriod);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionPeriod>> UpdatePromotionPeriod(long id, [FromBody] PromotionPeriodDto updatedPromotionPeriodDto)
        {
            var updatedPromotionPeriod = await _promotionPeriodService.UpdatePromotionPeriodAsync(id, updatedPromotionPeriodDto);
            if (updatedPromotionPeriod == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotionPeriod);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotionPeriod(long id)
        {
            var isDeleted = await _promotionPeriodService.DeletePromotionPeriodAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
