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
        private readonly IRepository<EnumPromotionType> _enumPromotionTypeRepository;

        public EnumPromotionTypeController(IRepository<EnumPromotionType> enumPromotionTypeRepository)
        {
            _enumPromotionTypeRepository = enumPromotionTypeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumPromotionType>> GetAllEnumPromotionType()
        {
            var enumPromotionType = _enumPromotionTypeRepository.GetAll().ToList();
            return Ok(enumPromotionType);
        }
    }
}
