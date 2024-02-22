namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumPromotionTypeController : ControllerBase
    {
        private readonly IGenericRepository<EnumPromotionType> _enumPromotionTypeRepository;

        public EnumPromotionTypeController(IGenericRepository<EnumPromotionType> enumPromotionTypeRepository)
        {
            _enumPromotionTypeRepository = enumPromotionTypeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumPromotionType>> GetAllEnumPromotionType()
        {
            var enumPromotionType = _enumPromotionTypeRepository.GetAllAsync();
            return Ok(enumPromotionType);
        }
    }
}
