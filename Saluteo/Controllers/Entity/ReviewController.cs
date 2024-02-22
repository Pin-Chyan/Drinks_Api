namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IGenericRepository<Review> _reviewRepository;

        public ReviewController(IGenericRepository<Review> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Review>> GetAllReviews()
        {
            var reviews = _reviewRepository.GetAllAsync();
            return Ok(reviews);
        }

        [HttpPost]
        public ActionResult CreateReview([FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var review = new Review
            {
                ReviewJson = reviewDto.ReviewJson,
                ReviewConfigurationId = reviewDto.ReviewConfigurationId,
                PromotionProductId = reviewDto.PromotionProductId,
                ClientId = reviewDto.ClientId
            };

            _reviewRepository.InsertAsync(review);

            return Ok(review);
        }
    }
}
