namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumReviewTypeController : ControllerBase
    {
        private readonly IRepository<EnumReviewType> _enumReviewTypeRepository;

        public EnumReviewTypeController(IRepository<EnumReviewType> enumReviewTypeRepository)
        {
            _enumReviewTypeRepository = enumReviewTypeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumReviewType>> GetAllEnumReviewType()
        {
            var enumReviewType = _enumReviewTypeRepository.GetAll().ToList();
            return Ok(enumReviewType);
        }
    }
}
