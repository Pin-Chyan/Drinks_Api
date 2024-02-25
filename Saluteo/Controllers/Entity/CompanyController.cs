namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;

    using Saluteo.Models.Entity;
    using Saluteo.Services;
    using Saluteo.Services.Entity;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompaniesAsync();

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanyById(long id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany([FromBody] CompanyDto companyDto)
        {
            var createdCompany = await _companyService.CreateCompanyAsync(companyDto);
            if (createdCompany == null)
            {
                return BadRequest("Invalid data");
            }

            return Ok(createdCompany);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> UpdateCompany(long id, [FromBody] CompanyDto updatedCompanyDto)
        {
            var updatedCompany = await _companyService.UpdateCompanyAsync(id, updatedCompanyDto);
            if (updatedCompany == null)
            {
                return NotFound();
            }

            return Ok(updatedCompany);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(long id)
        {
            var isDeleted = await _companyService.DeleteCompanyAsync(id);
            if (!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
