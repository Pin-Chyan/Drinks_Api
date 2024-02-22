namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class PromotionBranchController : ControllerBase
    {
        private readonly IGenericRepository<PromotionBranch> _promotionBranchRepository;

        public PromotionBranchController(IGenericRepository<PromotionBranch> promotionBranchRepository)
        {
            _promotionBranchRepository = promotionBranchRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Promotion>> GetAllPromotionBranches()
        {
            var promotionsBranches = _promotionBranchRepository.GetAllAsync();
            return Ok(promotionsBranches);
        }

        [HttpPost]
        public ActionResult CreatePromotionBranch([FromBody] PromotionBranchDto promotionBranchDto)
        {
            if (promotionBranchDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var promotionBranch = new PromotionBranch
            {
                BranchId = promotionBranchDto.BranchId,
                PromotionId = promotionBranchDto.PromotionId
            };

            _promotionBranchRepository.InsertAsync(promotionBranch);

            return Ok(promotionBranch);
        }
    }
}
