using Saluteo.Models.Entity;
using Saluteo.Repository;

namespace Saluteo.Services.Entity
{
    public class PromotionProductService
    {
        private readonly IGenericRepository<PromotionProduct> _PromotionProductRepository;

        public PromotionProductService(IGenericRepository<PromotionProduct> PromotionProductRepository)
        {
            _PromotionProductRepository = PromotionProductRepository;
        }

        public async Task<List<PromotionProduct>> GetAllPromotionProductsAsync()
        {
            var PromotionProducts = await _PromotionProductRepository.GetAllAsync();

            return PromotionProducts.ToList();
        }

        public async Task<PromotionProduct?> GetPromotionProductByIdAsync(long id)
        {
            var PromotionProduct = await _PromotionProductRepository.GetByIdAsync(id);
            if (PromotionProduct == null)
            {
                return null;
            }

            return PromotionProduct;
        }

        public async Task<PromotionProduct?> CreatePromotionProductAsync(PromotionProductDto promotionProductDto)
        {
            if (promotionProductDto == null)
            {
                return null;
            }

            var PromotionProduct = new PromotionProduct
            {
                // Barcode validation
                PromotionId = promotionProductDto.PromotionId,
                ProductId = promotionProductDto.ProductId,
            };

            await _PromotionProductRepository.InsertAsync(PromotionProduct);
            return PromotionProduct;
        }

        public async Task<PromotionProduct?> UpdatePromotionProductAsync(long id, PromotionProductDto updatedPromotionProductDto)
        {
            var existingPromotionProduct = await GetPromotionProductByIdAsync(id);
            if (existingPromotionProduct == null)
            {
                return null;
            }

            existingPromotionProduct.PromotionId = updatedPromotionProductDto.PromotionId;
            existingPromotionProduct.ProductId = updatedPromotionProductDto.ProductId;

            await _PromotionProductRepository.UpdateAsync(existingPromotionProduct);
            return existingPromotionProduct;
        }

        public async Task<bool> DeletePromotionProductAsync(long id)
        {
            var existingPromotionProduct = await _PromotionProductRepository.GetByIdAsync(id);
            if (existingPromotionProduct == null)
            {
                return false;
            }

            await _PromotionProductRepository.DeleteAsync(id);
            return true;
        }
    }
}
