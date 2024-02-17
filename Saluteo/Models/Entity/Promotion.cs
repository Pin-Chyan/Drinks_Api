namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Promotion
    {
        [Key]
        [Column("PkPromotionId")]
        public long PromotionId { get; set; }

        public double? Quantity { get; set; }

        public bool IsPriority { get; set; } = false;

        [Column("FkPromotionTypeId")]
        public long PromotionTypeId { get; set; }

        public EnumPromotionType PromotionType { get; set; }

        [Column("FkRecurringTypeId")]
        public long RecurringTypeId { get; set; }

        public EnumRecurringType RecurringType { get; set; }

        [Column("FkPromotionPeriodId")]
        public long PromotionPeriodId { get; set; }

        public PromotionPeriod PromotionPeriod { get; set; }

        [Column("FkDiscountId")]
        public long? DiscountId { get; set; }

        public Discount? Discount { get; set; }
    }
}