namespace Saluteo.Models.Entity
{
    public class UserBranchAccessDto
    {
        public long UserBranchAccessId { get; set; }

        public long UserId { get; set; }

        public long BranchId { get; set; }

        public long SecurityAccessCodeId { get; set; }
    }
}