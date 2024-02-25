using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services.Entity
{
    public class PromotionService
    {
        private readonly IGenericRepository<Promotion> _promotionRepository;

        public PromotionService(IGenericRepository<Promotion> PromotionRepository)
        {
            _promotionRepository = PromotionRepository;
        }

        public async Task<List<Promotion>> GetAllPromotionsAsync()
        {
            var Promotions = await _promotionRepository.GetAllAsync();

            return Promotions.ToList();
        }

        public async Task<Promotion?> GetPromotionByIdAsync(long id)
        {
            var Promotion = await _promotionRepository.GetByIdAsync(id);
            if (Promotion == null)
            {
                return null;
            }

            return Promotion;
        }

        public async Task<Promotion?> CreatePromotionAsync(PromotionDto promotionDto)
        {
            if (promotionDto == null)
            {
                return null;
            }

            var Promotion = new Promotion
            {
                Quantity = promotionDto.Quantity,
                IsPriority = promotionDto.IsPriority,
                PromotionTypeId = promotionDto.PromotionTypeId,
                RecurringTypeId = promotionDto.RecurringTypeId,
                PromotionPeriodId = promotionDto.PromotionPeriodId,
                DiscountId = promotionDto.DiscountId,
            };

            await _promotionRepository.InsertAsync(Promotion);
            return Promotion;
        }

        public async Task<Promotion?> UpdatePromotionAsync(long id, PromotionDto updatedPromotionDto)
        {
            var existingPromotion = await GetPromotionByIdAsync(id);
            if (existingPromotion == null)
            {
                return null;
            }

            existingPromotion.Quantity = updatedPromotionDto.Quantity;
            existingPromotion.IsPriority = updatedPromotionDto.IsPriority;
            existingPromotion.PromotionTypeId = updatedPromotionDto.PromotionTypeId;
            existingPromotion.RecurringTypeId = updatedPromotionDto.RecurringTypeId;
            existingPromotion.PromotionPeriodId = updatedPromotionDto.PromotionPeriodId;
            existingPromotion.DiscountId = updatedPromotionDto.DiscountId;

            await _promotionRepository.UpdateAsync(existingPromotion);
            return existingPromotion;
        }

        public async Task<bool> DeletePromotionAsync(long id)
        {
            var existingPromotion = await _promotionRepository.GetByIdAsync(id);
            if (existingPromotion == null)
            {
                return false;
            }

            await _promotionRepository.DeleteAsync(id);
            return true;
        }
    }
}
