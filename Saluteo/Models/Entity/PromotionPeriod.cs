namespace Saluteo.Models.Entity
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PromotionPeriod
    {
        [Key]
        [Column("pkPromotionPeriodId")]
        public long PromotionPeriodId { get; set; }

        // Represents a SQL DATE column
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        // Represents a SQL TIME column
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }
    }
}