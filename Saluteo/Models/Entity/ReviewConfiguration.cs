namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ReviewConfiguration
    {
        [Key]
        [Column("PkReviewConfigurationId")]
        public long ReviewConfigurationId { get; set; }

        [Column("FkPromotionId")]
        public long PromotionId { get; set; }

        public Promotion Promotion { get; set; }

        [Column("FkReviewTypeId")]
        public long ReviewTypeId { get; set; }

        public EnumReviewType ReviewType { get; set; }
    }
}