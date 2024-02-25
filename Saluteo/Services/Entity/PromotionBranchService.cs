namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class PromotionBranchService
    {
        private readonly IGenericRepository<PromotionBranch> _promotionBranchRepository;

        public PromotionBranchService(IGenericRepository<PromotionBranch> promotionBranchRepository)
        {
            _promotionBranchRepository = promotionBranchRepository;
        }

        public async Task<List<PromotionBranch>> GetAllPromotionBranchesAsync()
        {
            var promotionsBranches = await _promotionBranchRepository.GetAllAsync();

            return promotionsBranches.ToList();
        }

        public async Task<PromotionBranch?> GetPromotionBranchByIdAsync(long id)
        {
            var PromotionBranch = await _promotionBranchRepository.GetByIdAsync(id);

            return PromotionBranch;
        }

        public async Task<PromotionBranch?> CreatePromotionBranchAsync(PromotionBranchDto promotionBranchDto)
        {
            if (promotionBranchDto == null)
            {
                return null;
            }

            var promotionBranch = new PromotionBranch
            {
                BranchId = promotionBranchDto.BranchId,
                PromotionId = promotionBranchDto.PromotionId
            };

            await _promotionBranchRepository.InsertAsync(promotionBranch);
            return promotionBranch;
        }

        public async Task<PromotionBranch?> UpdatePromotionBranchAsync(long id, PromotionBranchDto updatedPromotionBranchDto)
        {
            var existingPromotionBranch = await _promotionBranchRepository.GetByIdAsync(id);
            if (existingPromotionBranch == null)
            {
                return null;
            }

            existingPromotionBranch.BranchId = updatedPromotionBranchDto.BranchId;
            existingPromotionBranch.PromotionId = updatedPromotionBranchDto.PromotionId;

            await _promotionBranchRepository.UpdateAsync(existingPromotionBranch);
            return existingPromotionBranch;
        }

        public async Task<bool> DeletePromotionBranchAsync(long id)
        {
            var existingPromotionBranch = await _promotionBranchRepository.GetByIdAsync(id);
            if (existingPromotionBranch == null)
            {
                return false;
            }

            await _promotionBranchRepository.DeleteAsync(id);
            return true;
        }
    }
}
