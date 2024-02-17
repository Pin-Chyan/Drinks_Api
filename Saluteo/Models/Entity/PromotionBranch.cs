namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PromotionBranch
    {
        [Key]
        [Column("PkPromotionBranchId")]
        public long PromotionBranchId { get; set; }

        [Column("FkBranchId")]
        public long BranchId { get; set; }

        public Branch Branch { get; set; }

        [Column("FkPromotionId")]
        public long PromotionId { get; set; }

        public Promotion Promotion { get; set; }
    }
}