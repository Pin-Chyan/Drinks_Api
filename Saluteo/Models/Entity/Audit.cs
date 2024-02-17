namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Audit
    {
        [Key]
        [Column("PkAuditId")]
        public long AuditId { get; set; }

        public string Table { get; set; }

        // Represents a JSON column in SQL
        public string JsonBefore { get; set; }

        public string JsonAfter { get; set; }

        public long CompanyId { get; set; }

        public Company Company { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }
    }
}