namespace Saluteo.Models.Entity
{
    using Saluteo.Models.Enums;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserBranchAccess
    {
        [Key]
        [Column("PkUserBranchAccessId")]
        public long UserBranchAccessId { get; set; }

        [Column("FkUserId")]
        public long UserId { get; set; }

        public User User { get; set; }

        [Column("FkBranchId")]
        public long BranchId { get; set; }

        public Branch Branch { get; set; }

        [Column("FkSecurityAccessCodeId")]
        public long SecurityAccessCodeId { get; set; }

        public EnumSecurityAccessCode SecurityAccessCode { get; set; }
    }
}