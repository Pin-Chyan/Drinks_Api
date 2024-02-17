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
        private readonly IRepository<EnumProductCategory> _enumProductCategoryRepository;

        public EnumProductCategoryController(IRepository<EnumProductCategory> enumProductCategoryRepository)
        {
            _enumProductCategoryRepository = enumProductCategoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumProductCategory>> GetAllEnumProductCategory()
        {
            var enumProductCategory = _enumProductCategoryRepository.GetAll().ToList();
            return Ok(enumProductCategory);
        }
    }
}
