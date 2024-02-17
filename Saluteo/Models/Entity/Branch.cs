namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Branch
    {
        [Key]
        [Column("PkBranchId")]
        public long BranchId { get; set; }

        public string BranchName { get; set; }

        [Column("FkCompanyId")]
        public long CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [Column("FkLocationId")]
        public long LocationId { get; set; }

        public virtual Location Location { get; set; }
    }
}