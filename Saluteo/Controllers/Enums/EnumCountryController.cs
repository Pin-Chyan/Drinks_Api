namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumCountryController : ControllerBase
    {
        private readonly IGenericRepository<EnumCountry> _enumCountryRepository;

        public EnumCountryController(IGenericRepository<EnumCountry> enumCountryRepository)
        {
            _enumCountryRepository = enumCountryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumCountry>> GetAllEnumCountry()
        {
            var enumCountry = _enumCountryRepository.GetAllAsync();
            return Ok(enumCountry);
        }
    }
}
