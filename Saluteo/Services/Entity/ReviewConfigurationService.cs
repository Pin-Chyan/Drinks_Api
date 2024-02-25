using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services.Entity
{
    public class ReviewConfigurationService
    {
        private readonly IGenericRepository<ReviewConfiguration> _ReviewConfigurationRepository;

        public ReviewConfigurationService(IGenericRepository<ReviewConfiguration> ReviewConfigurationRepository)
        {
            _ReviewConfigurationRepository = ReviewConfigurationRepository;
        }

        public async Task<List<ReviewConfiguration>> GetAllReviewConfigurationsAsync()
        {
            var ReviewConfigurations = await _ReviewConfigurationRepository.GetAllAsync();

            return ReviewConfigurations.ToList();
        }

        public async Task<ReviewConfiguration?> GetReviewConfigurationByIdAsync(long id)
        {
            var ReviewConfiguration = await _ReviewConfigurationRepository.GetByIdAsync(id);
            if (ReviewConfiguration == null)
            {
                return null;
            }

            return ReviewConfiguration;
        }

        public async Task<ReviewConfiguration?> CreateReviewConfigurationAsync(ReviewConfigurationDto reviewConfigurationDto)
        {
            if (reviewConfigurationDto == null)
            {
                return null;
            }

            var ReviewConfiguration = new ReviewConfiguration
            {
                PromotionId = reviewConfigurationDto.PromotionId,
                ReviewTypeId = reviewConfigurationDto.ReviewTypeId,
            };

            await _ReviewConfigurationRepository.InsertAsync(ReviewConfiguration);
            return ReviewConfiguration;
        }

        public async Task<ReviewConfiguration?> UpdateReviewConfigurationAsync(long id, ReviewConfigurationDto updatedReviewConfigurationDto)
        {
            var existingReviewConfiguration = await GetReviewConfigurationByIdAsync(id);
            if (existingReviewConfiguration == null)
            {
                return null;
            }

            existingReviewConfiguration.PromotionId = updatedReviewConfigurationDto.PromotionId;
            existingReviewConfiguration.ReviewTypeId = updatedReviewConfigurationDto.ReviewTypeId;

            await _ReviewConfigurationRepository.UpdateAsync(existingReviewConfiguration);
            return existingReviewConfiguration;
        }

        public async Task<bool> DeleteReviewConfigurationAsync(long id)
        {
            var existingReviewConfiguration = await _ReviewConfigurationRepository.GetByIdAsync(id);
            if (existingReviewConfiguration == null)
            {
                return false;
            }

            await _ReviewConfigurationRepository.DeleteAsync(id);
            return true;
        }
    }
}
