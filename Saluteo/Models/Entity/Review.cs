namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Review
    {
        [Key]
        [Column("PkReviewId")]
        public long ReviewId { get; set; }

        public string ReviewJson { get; set; }

        [Column("FkReviewConfigurationId")]
        public long ReviewConfigurationId { get; set; }

        public ReviewConfiguration ReviewConfiguration { get; set; }

        [Column("FkPromotionProductId")]
        public long PromotionProductId { get; set; }

        public PromotionProduct PromotionProduct { get; set; }

        [Column("FkClientId")]
        public long ClientId { get; set; }

        public Client Client { get; set; }
    }
}