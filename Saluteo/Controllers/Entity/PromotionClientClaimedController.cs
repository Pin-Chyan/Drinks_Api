namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionClientClaimedController : ControllerBase
    {
        private readonly IGenericRepository<PromotionClientClaimed> _promotionClientClaimedRepository;

        public PromotionClientClaimedController(IGenericRepository<PromotionClientClaimed> promotionClientClaimedRepository)
        {
            _promotionClientClaimedRepository = promotionClientClaimedRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PromotionClientClaimed>> GetAllPromotionClientClaims()
        {
            var claimedItems = _promotionClientClaimedRepository.GetAllAsync();
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

            _promotionClientClaimedRepository.InsertAsync(promotionClientClaimed);

            return Ok(promotionClientClaimed);
        }
    }
}
