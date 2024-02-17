namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IRepository<Promotion> _promotionRepository;

        public PromotionController(IRepository<Promotion> promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Promotion>> GetAllPromotions()
        {
            var promotions = _promotionRepository.GetAll().ToList();
            return Ok(promotions);
        }

        [HttpPost]
        public ActionResult CreatePromotion([FromBody] PromotionDto promotionDto)
        {
            if (promotionDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotion = new Promotion
            {
                Quantity = promotionDto.Quantity,
                IsPriority = promotionDto.IsPriority,
                PromotionTypeId = promotionDto.PromotionTypeId,
                RecurringTypeId = promotionDto.RecurringTypeId,
                PromotionPeriodId = promotionDto.PromotionPeriodId,
                DiscountId = promotionDto.DiscountId,
            };

            _promotionRepository.Insert(promotion);

            return Ok(promotion);
        }
    }
}
