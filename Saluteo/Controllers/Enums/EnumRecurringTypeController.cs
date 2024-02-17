namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumRecurringTypeController : ControllerBase
    {
        private readonly IRepository<EnumRecurringType> _enumRecurringTypeRepository;

        public EnumRecurringTypeController(IRepository<EnumRecurringType> enumRecurringTypeRepository)
        {
            _enumRecurringTypeRepository = enumRecurringTypeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumRecurringType>> GetAllEnumRecurringType()
        {
            var enumRecurringType = _enumRecurringTypeRepository.GetAll().ToList();
            return Ok(enumRecurringType);
        }
    }
}
