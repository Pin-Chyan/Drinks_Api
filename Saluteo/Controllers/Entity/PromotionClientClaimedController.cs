namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionClientClaimedController : ControllerBase
    {
        private readonly IRepository<PromotionClientClaimed> _promotionClientClaimedRepository;

        public PromotionClientClaimedController(IRepository<PromotionClientClaimed> promotionClientClaimedRepository)
        {
            _promotionClientClaimedRepository = promotionClientClaimedRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionClientClaimed>> GetAllPromotionClientClaims()
        {
            var claimedItems = _promotionClientClaimedRepository.GetAll().ToList();
            return Ok(claimedItems);
        }

        [HttpPost]
        public ActionResult CreatePromotionClientClaimed([FromBody] PromotionClientClaimedDto promotionClientClaimedDto)
        {
            if (promotionClientClaimedDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotionClientClaimed = new PromotionClientClaimed
            {
                PromotionId = promotionClientClaimedDto.PromotionId,
                ClientId = promotionClientClaimedDto.ClientId
            };

            _promotionClientClaimedRepository.Insert(promotionClientClaimed);

            return Ok(promotionClientClaimed);
        }
    }
}
