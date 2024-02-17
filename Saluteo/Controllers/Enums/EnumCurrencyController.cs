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
        private readonly IRepository<EnumCurrency> _enumCurrencyRepository;

        public EnumCurrencyController(IRepository<EnumCurrency> enumCurrencyRepository)
        {
            _enumCurrencyRepository = enumCurrencyRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumCurrency>> GetAllEnumCurrency()
        {
            var enumCurrency = _enumCurrencyRepository.GetAll().ToList();
            return Ok(enumCurrency);
        }
    }
}
