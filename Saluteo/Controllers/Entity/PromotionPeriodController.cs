namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionPeriodController : ControllerBase
    {
        private readonly IRepository<PromotionPeriod> _promotionPeriodRepository;

        public PromotionPeriodController(IRepository<PromotionPeriod> promotionPeriodRepository)
        {
            _promotionPeriodRepository = promotionPeriodRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionPeriod>> GetAllPromotionsPeriods()
        {
            var GetAllPromotionsPeriods = _promotionPeriodRepository.GetAll().ToList();
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

            _promotionPeriodRepository.Insert(promotionPeriod);

            return Ok(promotionPeriod);
        }
    }
}
