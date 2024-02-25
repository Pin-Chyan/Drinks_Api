namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Discount
    {
        [Key]
        [Column("PkDiscountId")]
        public long DiscountId { get; set; }

        [Column("FkValueTypeId")]
        public long ValueTypeId { get; set; }

        public EnumValueType? ValueType { get; set; }

        public decimal DiscountAmount { get; set; }
    }
}