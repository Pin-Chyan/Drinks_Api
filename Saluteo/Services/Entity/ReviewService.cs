using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services.Entity
{
    public class ReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository;

        public ReviewService(IGenericRepository<Review> ReviewRepository)
        {
            _reviewRepository = ReviewRepository;
        }

        public async Task<List<Review>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();

            return reviews.ToList();
        }

        public async Task<Review?> GetReviewByIdAsync(long id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null)
            {
                return null;
            }

            return review;
        }

        public async Task<Review?> CreateReviewAsync(ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return null;
            }

            var Review = new Review
            {
                // Barcode validation
                ReviewJson = reviewDto.ReviewJson,
                ReviewConfigurationId = reviewDto.ReviewConfigurationId,
                PromotionProductId = reviewDto.PromotionProductId,
                ClientId = reviewDto.ClientId,
            };

            await _reviewRepository.InsertAsync(Review);
            return Review;
        }

        public async Task<Review?> UpdateReviewAsync(long id, ReviewDto updatedReviewDto)
        {
            var existingReview = await GetReviewByIdAsync(id);
            if (existingReview == null)
            {
                return null;
            }

            existingReview.ReviewJson = updatedReviewDto.ReviewJson;
            existingReview.ReviewConfigurationId = updatedReviewDto.ReviewConfigurationId;
            existingReview.PromotionProductId = updatedReviewDto.PromotionProductId;
            existingReview.ClientId = updatedReviewDto.ClientId;

            await _reviewRepository.UpdateAsync(existingReview);
            return existingReview;
        }

        public async Task<bool> DeleteReviewAsync(long id)
        {
            var existingReview = await _reviewRepository.GetByIdAsync(id);
            if (existingReview == null)
            {
                return false;
            }

            await _reviewRepository.DeleteAsync(id);
            return true;
        }
    }
}
