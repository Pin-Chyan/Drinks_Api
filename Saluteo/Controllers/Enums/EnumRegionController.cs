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
        private readonly IRepository<EnumRegion> _enumRegionRepository;

        public EnumRegionController(IRepository<EnumRegion> enumRegionRepository)
        {
            _enumRegionRepository = enumRegionRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumRegion>> GetAllEnumRegion()
        {
            var enumRegion = _enumRegionRepository.GetAll().Include(_ => _.Country).ToList();
            return Ok(enumRegion);
        }
    }
}
