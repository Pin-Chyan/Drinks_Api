namespace Saluteo.Controllers.Entity
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyController(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetAllCompanies()
        {
            var companies = _companyRepository.GetAll()
                .Include(_ => _.CompanyCategory)
                .ToList();

            return Ok(companies);
        }

        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(long id)
        {
            var company = _companyRepository.GetById(id);

            if (company == null)
            {
                return NotFound();
            }

            _companyRepository.LoadNavigationProperties(c => c.CompanyCategory);

            return Ok(company);
        }

        [HttpPost]
        public ActionResult CreateCompany([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Mapper :/
            var company = new Company
            {
                CompanyName = companyDto.CompanyName,
                CompanyCategoryId = companyDto.CompanyCategoryId
            };

            _companyRepository.Insert(company);
            _companyRepository.LoadNavigationProperties(c => c.CompanyCategory);

            return Ok(company);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCompany(long id, [FromBody] CompanyDto updatedCompanyDto)
        {
            if (updatedCompanyDto == null)
            {
                return BadRequest("Invalid data");
            }

            var existingCompany = _companyRepository.GetById(id);

            if (existingCompany == null)
            {
                return NotFound();
            }

            // Update properties of the existing entity
            existingCompany.CompanyName = updatedCompanyDto.CompanyName;
            existingCompany.CompanyCategoryId = updatedCompanyDto.CompanyCategoryId;

            _companyRepository.Update(existingCompany);
            _companyRepository.LoadNavigationProperties(c => c.CompanyCategory);

            return Ok(existingCompany);
        }
    }
}
