namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PromotionClientClaimed
    {
        [Key]
        [Column("PkPromotionClientClaimedId")]
        public long PromotionClientClaimedId { get; set; }

        [Column("FkPromotionId")]
        public long PromotionId { get; set; }

        public Promotion? Promotion { get; set; }

        [Column("FkClientId")]
        public long ClientId { get; set; }

        public Client? Client { get; set; }
    }
}