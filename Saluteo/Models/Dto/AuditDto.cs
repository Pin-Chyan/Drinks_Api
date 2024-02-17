namespace Saluteo.Models.Entity
{
    public class AuditDto
    {
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