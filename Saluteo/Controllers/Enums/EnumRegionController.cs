namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumRegionController : ControllerBase
    {
        private readonly IGenericRepository<EnumRegion> _enumRegionRepository;

        public EnumRegionController(IGenericRepository<EnumRegion> enumRegionRepository)
        {
            _enumRegionRepository = enumRegionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumRegion>> GetAllEnumRegion()
        {
            var enumRegion = _enumRegionRepository.GetAllAsync();
            return Ok(enumRegion);
        }
    }
}
