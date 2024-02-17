namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class ReviewConfigurationsController : ControllerBase
    {
        private readonly IRepository<ReviewConfiguration> _reviewConfigurationRepository;

        public ReviewConfigurationsController(IRepository<ReviewConfiguration> reviewConfigurationRepository)
        {
            _reviewConfigurationRepository = reviewConfigurationRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewConfiguration>> GetAllReviewConfigurations()
        {
            var reviewConfiguration = _reviewConfigurationRepository.GetAll().ToList();
            return Ok(reviewConfiguration);
        }

        [HttpPost]
        public ActionResult CreateReviewConfiguration([FromBody] ReviewConfigurationDto reviewConfigurationDto)
        {
            if (reviewConfigurationDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var reviewConfiguration = new ReviewConfiguration
            {
                PromotionId = reviewConfigurationDto.PromotionId,
                ReviewTypeId = reviewConfigurationDto.ReviewTypeId
            };

            _reviewConfigurationRepository.Insert(reviewConfiguration);

            return Ok(reviewConfiguration);
        }
    }
}
