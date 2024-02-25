namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewConfigurationController : ControllerBase
    {
        private readonly ReviewConfigurationService _reviewConfigurationService;

        public ReviewConfigurationController(ReviewConfigurationService ReviewConfigurationService)
        {
            _reviewConfigurationService = ReviewConfigurationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewConfiguration>>> GetAllReviewConfigurationes()
        {
            var reviewConfigurations = await _reviewConfigurationService.GetAllReviewConfigurationsAsync();

            return Ok(reviewConfigurations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewConfiguration>> GetReviewConfigurationById(long id)
        {
            var reviewConfiguration = await _reviewConfigurationService.GetReviewConfigurationByIdAsync(id);
            if (reviewConfiguration == null)
            {
                return NotFound();
            }

            return Ok(reviewConfiguration);
        }

        [HttpPost]
        public async Task<ActionResult<ReviewConfiguration>> CreateReviewConfiguration([FromBody] ReviewConfigurationDto reviewConfigurationDto)
        {
            var createdReviewConfiguration = await _reviewConfigurationService.CreateReviewConfigurationAsync(reviewConfigurationDto);
            if (createdReviewConfiguration == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdReviewConfiguration);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewConfiguration>> UpdateReviewConfiguration(long id, [FromBody] ReviewConfigurationDto updatedReviewConfigurationDto)
        {
            var updatedReviewConfiguration = await _reviewConfigurationService.UpdateReviewConfigurationAsync(id, updatedReviewConfigurationDto);
            if (updatedReviewConfiguration == null)
            {
                return NotFound();
            }

            return Ok(updatedReviewConfiguration);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReviewConfiguration(long id)
        {
            var isDeleted = await _reviewConfigurationService.DeleteReviewConfigurationAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
