namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionBranchController : ControllerBase
    {
        private readonly PromotionBranchService _promotionBranchService;

        public PromotionBranchController(PromotionBranchService promotionBranchService)
        {
            _promotionBranchService = promotionBranchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromotionBranch>>> GetAllPromotionBranches()
        {
            var promotionBranches = await _promotionBranchService.GetAllPromotionBranchesAsync();

            return Ok(promotionBranches);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromotionBranch>> GetPromotionBranchById(long id)
        {
            var promotionBranch = await _promotionBranchService.GetPromotionBranchByIdAsync(id);
            if (promotionBranch == null)
            {
                return NotFound();
            }

            return Ok(promotionBranch);
        }

        [HttpPost]
        public async Task<ActionResult<PromotionBranch>> CreatePromotionBranch([FromBody] PromotionBranchDto promotionBranchDto)
        {
            var createdPromotionBranch = await _promotionBranchService.CreatePromotionBranchAsync(promotionBranchDto);
            if (createdPromotionBranch == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdPromotionBranch);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PromotionBranch>> UpdatePromotionBranch(long id, [FromBody] PromotionBranchDto updatedPromotionBranchDto)
        {
            var updatedPromotionBranch = await _promotionBranchService.UpdatePromotionBranchAsync(id, updatedPromotionBranchDto);
            if (updatedPromotionBranch == null)
            {
                return NotFound();
            }

            return Ok(updatedPromotionBranch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotionBranch(long id)
        {
            var isDeleted = await _promotionBranchService.DeletePromotionBranchAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
