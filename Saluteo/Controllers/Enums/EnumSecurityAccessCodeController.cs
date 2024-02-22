namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumSecurityAccessCodeController : ControllerBase
    {
        private readonly IGenericRepository<EnumSecurityAccessCode> _enumSecurityAccessCodeRepository;

        public EnumSecurityAccessCodeController(IGenericRepository<EnumSecurityAccessCode> enumSecurityAccessCodeRepository)
        {
            _enumSecurityAccessCodeRepository = enumSecurityAccessCodeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumSecurityAccessCode>> GetAllEnumSecurityAccessCode()
        {
            var enumSecurityAccessCode = _enumSecurityAccessCodeRepository.GetAllAsync();
            return Ok(enumSecurityAccessCode);
        }
    }
}
