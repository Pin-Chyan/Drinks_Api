namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumValueTypeController : ControllerBase
    {
        private readonly IGenericRepository<EnumValueType> _enumValueTypeRepository;

        public EnumValueTypeController(IGenericRepository<EnumValueType> enumValueTypeRepository)
        {
            _enumValueTypeRepository = enumValueTypeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumValueType>> GetAllEnumValueType()
        {
            var enumValueType = _enumValueTypeRepository.GetAllAsync();
            return Ok(enumValueType);
        }
    }
}
