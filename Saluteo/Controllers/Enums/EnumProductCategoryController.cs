namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumProductCategoryController : ControllerBase
    {
        private readonly IGenericRepository<EnumProductCategory> _enumProductCategoryRepository;

        public EnumProductCategoryController(IGenericRepository<EnumProductCategory> enumProductCategoryRepository)
        {
            _enumProductCategoryRepository = enumProductCategoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumProductCategory>> GetAllEnumProductCategory()
        {
            var enumProductCategory = _enumProductCategoryRepository.GetAllAsync();
            return Ok(enumProductCategory);
        }
    }
}
