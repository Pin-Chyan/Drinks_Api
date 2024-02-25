namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;

        public ReviewController(ReviewService ReviewService)
        {
            this._reviewService = ReviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetAllReviews()
        {
            var reviews = await _reviewService.GetAllReviewsAsync();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReviewById(long id)
        {
            var review = await _reviewService.GetReviewByIdAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        [HttpPost]
        public async Task<ActionResult<Review>> CreateReview([FromBody] ReviewDto reviewDto)
        {
            var createdReview = await _reviewService.CreateReviewAsync(reviewDto);
            if (createdReview == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdReview);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Review>> UpdateReview(long id, [FromBody] ReviewDto updatedReviewDto)
        {
            var updatedReview = await _reviewService.UpdateReviewAsync(id, updatedReviewDto);
            if (updatedReview == null)
            {
                return NotFound();
            }

            return Ok(updatedReview);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReview(long id)
        {
            var isDeleted = await _reviewService.DeleteReviewAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
