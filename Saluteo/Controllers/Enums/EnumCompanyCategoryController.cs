﻿namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Models.Enums;
    using Saluteo.Repository;

    [Route("api/enum/[controller]")]
    [ApiController]
    public class EnumCompanyCategoryController : ControllerBase
    {
        private readonly IGenericRepository<EnumCompanyCategory> _enumCompanyCategoryRepository;

        public EnumCompanyCategoryController(IGenericRepository<EnumCompanyCategory> enumCompanyCategoryRepository)
        {
            _enumCompanyCategoryRepository = enumCompanyCategoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EnumCompanyCategory>> GetAllEnumCompanyCategory()
        {
            var enumCompanyCategory = _enumCompanyCategoryRepository.GetAllAsync();
            return Ok(enumCompanyCategory);
        }
    }
}
