namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class PromotionClientClaimedService
    {
        private readonly IGenericRepository<PromotionClientClaimed> _promotionClientClaimedRepository;

        public PromotionClientClaimedService(IGenericRepository<PromotionClientClaimed> promotionClientClaimedRepository)
        {
            _promotionClientClaimedRepository = promotionClientClaimedRepository;
        }

        public async Task<List<PromotionClientClaimed>> GetAllPromotionClientClaimsAsync()
        {
            var claimedItems = await _promotionClientClaimedRepository.GetAllAsync();

            return claimedItems.ToList();
        }

        public async Task<PromotionClientClaimed?> GetPromotionClientClaimedByIdAsync(long id)
        {
            var promotionClientClaimed = await _promotionClientClaimedRepository.GetByIdAsync(id);

            return promotionClientClaimed;
        }

        public async Task<PromotionClientClaimed?> CreatePromotionClientClaimedAsync(PromotionClientClaimedDto promotionClientClaimedDto)
        {
            if (promotionClientClaimedDto == null)
            {
                return null;
            }

            var promotionClientClaimed = new PromotionClientClaimed
            {
                PromotionId = promotionClientClaimedDto.PromotionId,
                ClientId = promotionClientClaimedDto.ClientId
            };

            await _promotionClientClaimedRepository.InsertAsync(promotionClientClaimed);
            return promotionClientClaimed;
        }

        public async Task<PromotionClientClaimed?> UpdatePromotionClientClaimedAsync(long id, PromotionClientClaimedDto updatedPromotionClientClaimedDto)
        {
            var existingPromotionClientClaimed = await _promotionClientClaimedRepository.GetByIdAsync(id);
            if (existingPromotionClientClaimed == null)
            {
                return null;
            }

            existingPromotionClientClaimed.PromotionId = updatedPromotionClientClaimedDto.PromotionId;
            existingPromotionClientClaimed.ClientId = updatedPromotionClientClaimedDto.ClientId;

            await _promotionClientClaimedRepository.UpdateAsync(existingPromotionClientClaimed);
            return existingPromotionClientClaimed;
        }

        public async Task<bool> DeletePromotionClientClaimedAsync(long id)
        {
            var existingPromotionClientClaimed = await _promotionClientClaimedRepository.GetByIdAsync(id);
            if (existingPromotionClientClaimed == null)
            {
                return false;
            }

            await _promotionClientClaimedRepository.DeleteAsync(id);
            return true;
        }
    }
}
