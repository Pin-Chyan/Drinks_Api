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
        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        // Represents a SQL TIME column
        public TimeSpan? startTime { get; set; }

        public TimeSpan? endTime { get; set; }
    }
}