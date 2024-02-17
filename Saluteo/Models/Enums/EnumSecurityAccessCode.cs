namespace Saluteo.Models.Enums
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class EnumSecurityAccessCode
    {
        [Column("PkSecurityAccessCodeId")]
        public long SecurityAccessCodeId { get; set; }

        public string SecurityDescription { get; set; }
    }
}