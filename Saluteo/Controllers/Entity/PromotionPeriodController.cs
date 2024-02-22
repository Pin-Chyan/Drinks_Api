namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionPeriodController : ControllerBase
    {
        private readonly IGenericRepository<PromotionPeriod> _promotionPeriodRepository;

        public PromotionPeriodController(IGenericRepository<PromotionPeriod> promotionPeriodRepository)
        {
            _promotionPeriodRepository = promotionPeriodRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionPeriod>> GetAllPromotionsPeriods()
        {
            var GetAllPromotionsPeriods = _promotionPeriodRepository.GetAllAsync();
            return Ok(GetAllPromotionsPeriods);
        }

        [HttpPost]
        public ActionResult CreatePromotionPeriod([FromBody] PromotionPeriodDto promotionPeriodDto)
        {
            if (promotionPeriodDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotionPeriod = new PromotionPeriod
            {
                startDate = promotionPeriodDto.startDate,
                endDate = promotionPeriodDto.endDate,
                startTime = promotionPeriodDto?.startTime,
                endTime = promotionPeriodDto?.endTime,
            };

            _promotionPeriodRepository.InsertAsync(promotionPeriod);

            return Ok(promotionPeriod);
        }
    }
}
