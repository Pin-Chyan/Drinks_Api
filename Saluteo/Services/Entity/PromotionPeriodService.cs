namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class PromotionPeriodService
    {
        private readonly IGenericRepository<PromotionPeriod> _promotionPeriodRepository;

        public PromotionPeriodService(IGenericRepository<PromotionPeriod> PromotionPeriodRepository)
        {
            _promotionPeriodRepository = PromotionPeriodRepository;
        }

        public async Task<List<PromotionPeriod>> GetAllPromotionPeriodsAsync()
        {
            var promotionPeriods = await _promotionPeriodRepository.GetAllAsync();

            return promotionPeriods.ToList();
        }

        public async Task<PromotionPeriod?> GetPromotionPeriodByIdAsync(long id)
        {
            var promotionPeriod = await _promotionPeriodRepository.GetByIdAsync(id);
            if (promotionPeriod == null)
            {
                return null;
            }

            return promotionPeriod;
        }

        public async Task<PromotionPeriod?> CreatePromotionPeriodAsync(PromotionPeriodDto promotionPeriodDto)
        {
            if (promotionPeriodDto == null)
            {
                return null;
            }

            var PromotionPeriod = new PromotionPeriod
            {
                // Barcode validation
                StartDate = promotionPeriodDto.StartDate,
                EndDate = promotionPeriodDto.EndDate,
                StartTime = promotionPeriodDto.StartTime,
                EndTime = promotionPeriodDto.EndTime
            };

            await _promotionPeriodRepository.InsertAsync(PromotionPeriod);
            return PromotionPeriod;
        }

        public async Task<PromotionPeriod?> UpdatePromotionPeriodAsync(long id, PromotionPeriodDto updatedPromotionPeriodDto)
        {
            var existingPromotionPeriod = await GetPromotionPeriodByIdAsync(id);
            if (existingPromotionPeriod == null)
            {
                return null;
            }

            existingPromotionPeriod.StartDate = updatedPromotionPeriodDto.StartDate;
            existingPromotionPeriod.EndDate = updatedPromotionPeriodDto.EndDate;
            existingPromotionPeriod.StartTime = updatedPromotionPeriodDto.StartTime;
            existingPromotionPeriod.EndTime = updatedPromotionPeriodDto.EndTime;

            await _promotionPeriodRepository.UpdateAsync(existingPromotionPeriod);
            return existingPromotionPeriod;
        }

        public async Task<bool> DeletePromotionPeriodAsync(long id)
        {
            var existingPromotionPeriod = await _promotionPeriodRepository.GetByIdAsync(id);
            if (existingPromotionPeriod == null)
            {
                return false;
            }

            await _promotionPeriodRepository.DeleteAsync(id);
            return true;
        }
    }
}