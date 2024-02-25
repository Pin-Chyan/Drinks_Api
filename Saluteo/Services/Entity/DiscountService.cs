namespace Saluteo.Services.Entity
{
    using Saluteo.Models.Entity;
    using Saluteo.Repository;

    public class DiscountService
    {
        private readonly IGenericRepository<Discount> _discountRepository;

        public DiscountService(IGenericRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<List<Discount>> GetAllDiscountsAsync()
        {
            var discounts = await _discountRepository.GetAllAsync();
            return discounts.ToList();
        }

        public async Task<Discount?> GetDiscountByIdAsync(long id)
        {
            var discount = await _discountRepository.GetByIdAsync(id);
            if (discount == null)
            {
                return null;
            }

            await _discountRepository.LoadNavigationPropertiesAsync(_ => _.ValueType);
            return discount;
        }

        public async Task<Discount?> CreateDiscountAsync(DiscountDto discountDto)
        {
            if (discountDto == null)
            {
                return null;
            }

            var discount = new Discount
            {
                ValueTypeId = discountDto.ValueTypeId,
                DiscountAmount = discountDto.DiscountAmount
            };

            await _discountRepository.InsertAsync(discount);
            return discount;
        }

        public async Task<Discount?> UpdateDiscountAsync(long id, DiscountDto updatedDiscountDto)
        {
            var existingDiscount = await _discountRepository.GetByIdAsync(id);

            if (existingDiscount == null)
            {
                return null;
            }

            existingDiscount.ValueTypeId = updatedDiscountDto.ValueTypeId;
            existingDiscount.DiscountAmount = updatedDiscountDto.DiscountAmount;

            await _discountRepository.UpdateAsync(existingDiscount);
            return existingDiscount;
        }

        // delete? like this?
        public async Task<bool> DeleteDiscountAsync(long id)
        {
            var existingDiscount = await _discountRepository.GetByIdAsync(id);

            if (existingDiscount == null)
            {
                return false;
            }

            await _discountRepository.DeleteAsync(id);
            return true;
        }
    }
}
