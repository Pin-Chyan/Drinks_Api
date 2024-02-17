namespace Saluteo.Models.Entity
{
    public class PromotionDto
    {
        public double? Quantity { get; set; }

        public bool IsPriority { get; set; } = false;

        public long PromotionTypeId { get; set; }

        public long RecurringTypeId { get; set; }

        public long PromotionPeriodId { get; set; }

        public long? DiscountId { get; set; }
    }
}