namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class CompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;

        public CompanyService(IGenericRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();

            return companies.ToList();
        }

        public async Task<Company> GetCompanyByIdAsync(long id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company == null)
            {
                return null; // Return null if company not found
            }

            await _companyRepository.LoadNavigationPropertiesAsync(c => c.CompanyCategory);
            return company;
        }

        public async Task<Company> CreateCompanyAsync(CompanyDto companyDto)
        {
            if (companyDto == null)
            {
                return null;
            }

            var company = new Company
            {
                CompanyName = companyDto.CompanyName,
                CompanyCategoryId = companyDto.CompanyCategoryId
            };

            await _companyRepository.InsertAsync(company);
            await _companyRepository.LoadNavigationPropertiesAsync(c => c.CompanyCategory);
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(long id, CompanyDto updatedCompanyDto)
        {
            if (updatedCompanyDto == null)
            {
                return null;
            }

            var existingCompany = await _companyRepository.GetByIdAsync(id);

            if (existingCompany == null)
            {
                return null; // Return null if company not found
            }

            // Update properties of the existing entity
            existingCompany.CompanyName = updatedCompanyDto.CompanyName;
            existingCompany.CompanyCategoryId = updatedCompanyDto.CompanyCategoryId;

            await _companyRepository.UpdateAsync(existingCompany);
            await _companyRepository.LoadNavigationPropertiesAsync(c => c.CompanyCategory);

            return existingCompany;
        }

        public async Task<bool> DeleteCompanyAsync(long id)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(id);
            if (existingCompany == null)
            {
                return false;
            }

            await _companyRepository.DeleteAsync(id);
            return true;
        }
    }
}
