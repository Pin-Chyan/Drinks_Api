namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IGenericRepository<Promotion> _promotionRepository;

        public PromotionController(IGenericRepository<Promotion> promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Promotion>> GetAllPromotions()
        {
            var promotions = _promotionRepository.GetAllAsync();
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

            _promotionRepository.InsertAsync(promotion);

            return Ok(promotion);
        }
    }
}
