namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumCurrencyController : ControllerBase
    {
        private readonly IGenericRepository<EnumCurrency> _enumCurrencyRepository;

        public EnumCurrencyController(IGenericRepository<EnumCurrency> enumCurrencyRepository)
        {
            _enumCurrencyRepository = enumCurrencyRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumCurrency>> GetAllEnumCurrency()
        {
            var enumCurrency = _enumCurrencyRepository.GetAllAsync();
            return Ok(enumCurrency);
        }
    }
}
