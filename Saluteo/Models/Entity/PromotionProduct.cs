namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PromotionProduct
    {
        [Key]
        [Column("PkPromotionProductId")]
        public long PromotionProductId { get; set; }

        [Column("FkPromotionId")]
        public long PromotionId { get; set; }

        public Promotion Promotion { get; set; }

        [Column("FkProductId")]
        public long ProductId { get; set; }

        public Product Product { get; set; }
    }
}