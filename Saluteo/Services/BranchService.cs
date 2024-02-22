namespace Saluteo.Services
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class BranchService
    {
        private readonly IGenericRepository<Branch> _branchRepository;

        public BranchService(IGenericRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<List<Branch>> GetAllBranchesAsync()
        {
            var queryableBranches = await _branchRepository.GetAllAsync();
            var branches = await queryableBranches.ToListAsync();

            return branches;
        }

        public async Task<Branch?> GetBranchByIdAsync(long id)
        {
            var branch = await _branchRepository.GetByIdAsync(id);

            if (branch == null)
            {
                return null;
            }

            // reconsider (talk about how we want to handle in our usuage)
            await _branchRepository.LoadNavigationPropertiesAsync(
                b => b.Company,
                b => b.Company.CompanyCategory,
                b => b.Location,
                b => b.Location.Region,
                b => b.Location.Region.Country
            );

            return branch;
        }

        public async Task<Branch?> CreateBranchAsync(BranchDto branchDto)
        {
            if (branchDto == null)
            {
                return null; // Return null if branchDto is null
            }

            // Mapper :/
            var branch = new Branch
            {
                BranchName = branchDto.BranchName,
                CompanyId = branchDto.CompanyId,
                LocationId = branchDto.LocationId,
            };

            await _branchRepository.InsertAsync(branch);

            return branch;
        }

        public async Task<Branch?> UpdateBranchAsync(long id, BranchDto updatedBranchDto)
        {
            if (updatedBranchDto == null)
            {
                return null; // Return null if updatedBranchDto is null
            }

            var existingBranch = await _branchRepository.GetByIdAsync(id);

            if (existingBranch == null)
            {
                return null; // Return null if branch not found
            }

            // Update properties of the existing entity
            existingBranch.BranchName = updatedBranchDto.BranchName;
            existingBranch.CompanyId = updatedBranchDto.CompanyId;
            existingBranch.LocationId = updatedBranchDto.LocationId;

            await _branchRepository.UpdateAsync(existingBranch);
            await _branchRepository.LoadNavigationPropertiesAsync(
                b => b.Company,
                b => b.Company.CompanyCategory,
                b => b.Location,
                b => b.Location.Region,
                b => b.Location.Region.Country
            );

            return existingBranch;
        }
    }
}
